using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Xml;

namespace WcfRestAuthentication.MessageFormatter
{
    public class CustomMessageFormatter : IClientMessageFormatter
    {
        IClientMessageFormatter InnerClientFormatter;
        IDispatchMessageFormatter InnerDispatchFormatter;
 
        private const string ROOT = "MessageData";
 
        public CustomMessageFormatter(IClientMessageFormatter innerClientFormatter)
        {
            InnerClientFormatter = innerClientFormatter;
        }
 
        public CustomMessageFormatter(IDispatchMessageFormatter innerDispatchFormatter)
        {
            InnerDispatchFormatter = innerDispatchFormatter;
        }
 
        #region Stream Compression
 
        private Stream CompressStream(Stream inStream)
        {
            var outStream = new MemoryStream();
            CompressStream(inStream, outStream);
            outStream.Position = 0;
            return outStream;
        }
        /// <summary>
        /// Compress 'inStream' and write all data into 'outStream'
        /// </summary>
        private void CompressStream(Stream inStream, Stream outStream)
        {
            using (var gzipStream = new GZipStream(outStream, CompressionMode.Compress, true))
            {
                gzipStream.Flush();
                inStream.CopyTo(gzipStream);
            }
        }
        /// <summary>
        /// Get decompression stream. Not dispose 'inStream' while not end work with stream.
        /// </summary>    
        private Stream DecompressStream(Stream inStream, bool leaveOpenInStream = false)
        {
            return new GZipStream(inStream, CompressionMode.Decompress, leaveOpenInStream);
        }
 
        #endregion
 
        #region IDispatchMessageFormatter
 
        public void DeserializeRequest(System.ServiceModel.Channels.Message message, object[] parameters)
        {
            Polenter.Serialization.SharpSerializer serializer = new Polenter.Serialization.SharpSerializer(true);
            using (var inStream = GetBodyInnerContentStream(message))
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = serializer.Deserialize(inStream);
                }
            }
        }
 
        public System.ServiceModel.Channels.Message SerializeReply(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters, object result)
        {
            //Polenter.Serialization.SharpSerializer serializer = new Polenter.Serialization.SharpSerializer(true);
 
            ////stream will be closed in the ContentStreamProvider
            //MemoryStream outStream = new MemoryStream();
            //serializer.Serialize(result, outStream);
 
            //outStream.Position = 0;
 
            //return Message.CreateMessage(messageVersion, null, new ContentStreamProvider(CompressStream(outStream), ROOT));
            return null;
        }
 
        #endregion
 
        /// <summary>
        /// Create a new message bases on other one and with body writer stream.
        /// </summary>
        /// <param name="prototype"></param>
        /// <param name="sourceStream">Stream of body content</param>
        /// <param name="tagName"></param>
        private static Message CreateMessage(Message prototype, Stream contentStream, string tagName = null)
        {
            //Message msg = Message.CreateMessage(prototype.Version, null, new ContentStreamProvider(contentStream, tagName));
            //msg.Headers.CopyHeadersFrom(prototype);
            //msg.Properties.CopyProperties(prototype.Properties);
            //return msg;
            return null;
        }
 
        #region IClientMessageFormatter
 
        public object DeserializeReply(Message message, object[] parameters)
        {
            Polenter.Serialization.SharpSerializer serializer = new Polenter.Serialization.SharpSerializer(true);
 
            using (var inStream = GetBodyInnerContentStream(message))
            {
                return serializer.Deserialize(DecompressStream(inStream, true));
            }
        }
 
        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            Polenter.Serialization.SharpSerializer serializer = new Polenter.Serialization.SharpSerializer(true);
 
            //stream will be closed in the ContentStreamProvider
            MemoryStream outStream = new MemoryStream();
 
            foreach (var parameter in parameters)
            {
                serializer.Serialize(parameter, outStream);
            }
 
            //check
            outStream.Position = 0;
 
            Message prototype = null;
            if (InnerClientFormatter != null)
            {
                prototype = InnerClientFormatter.SerializeRequest(messageVersion, parameters);
                messageVersion = prototype.Version;
            }
 
            return CreateMessage(prototype, outStream, ROOT);
        }
 
        #endregion
 
        /// <summary>
        /// Gets stream of inner element content of the message body.
        /// </summary>
        private Stream GetBodyInnerContentStream(Message message)
        {
            using (var bodyStream = new MemoryStream())
            {
                using (XmlDictionaryWriter bodyWriter = XmlDictionaryWriter.CreateBinaryWriter(bodyStream))
                {
                    message.WriteBodyContents(bodyWriter);
                    bodyWriter.Flush();
                    bodyStream.Position = 0;
 
                    using (var bodyReader = XmlDictionaryReader.CreateBinaryReader(bodyStream, XmlDictionaryReaderQuotas.Max))
                    {
                        bodyReader.MoveToStartElement();
                        var contentStream = new MemoryStream(bodyReader.ReadElementContentAsBase64());
                        contentStream.Position = 0;
                        return contentStream;
                    }
                }
            }
        }
    }

    public class InboundMessageFormatter : IClientMessageFormatter
    {

        public object DeserializeReply(Message message, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}