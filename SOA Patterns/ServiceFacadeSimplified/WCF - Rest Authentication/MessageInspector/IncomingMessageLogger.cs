using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Xml;

namespace WcfRestAuthentication.MessageInspector
{
    public class IncomingMessageLogger : IDispatchMessageInspector
    {
        const string MessageLogFolder = @"c:\temp\";
        static int messageLogFileIndex = 0;

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string messageFileName = string.Format("{0}Log{1:000}_Incoming.txt", MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
            Uri requestUri = request.Headers.To;

            HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            // Do what ever you want to do with JSON data.
            string jsonMessage = this.MessageToString(ref request);

            return requestUri;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        private string MessageToString(ref Message message)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately
                    return this.ReadRawBody(ref message);
            }

            message.WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());

            ms.Position = 0;

            XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);

            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
    }
}
