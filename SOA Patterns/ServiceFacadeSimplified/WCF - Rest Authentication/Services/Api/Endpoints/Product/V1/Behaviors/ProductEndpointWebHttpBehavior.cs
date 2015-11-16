using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class ProductEndpointWebHttpBehavior : WebHttpBehavior
    {
        public override WebMessageFormat DefaultOutgoingRequestFormat
        {
            get { return defaultOutgoingRequestFormat; }
            set { defaultOutgoingRequestFormat = value; }
        }
        private WebMessageFormat defaultOutgoingRequestFormat;

        public override WebMessageFormat DefaultOutgoingResponseFormat
        {
            get { return defaultOutgoingResponseFormat; }
            set { defaultOutgoingResponseFormat = value; }
        }
        private WebMessageFormat defaultOutgoingResponseFormat;

        public ProductEndpointWebHttpBehavior()
        {
            this.defaultOutgoingRequestFormat = WebMessageFormat.Json;
            this.defaultOutgoingResponseFormat = WebMessageFormat.Json;
        }

        public ProductEndpointWebHttpBehavior(IDispatchMessageInspector messageInspector)
        {
        }

        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription,
            ServiceEndpoint endpoint)
        {
            foreach (var item in operationDescription.Messages[0].Body.Parts)
            {
                item.Type = typeof(string);
            }

            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }

        public override void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}