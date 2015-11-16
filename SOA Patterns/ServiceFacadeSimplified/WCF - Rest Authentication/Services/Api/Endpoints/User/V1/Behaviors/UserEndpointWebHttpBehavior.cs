using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WcfRestAuthentication.Extensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.User.V1.Behaviors
{
    public class UserEndpointWebHttpBehavior : WebHttpBehavior
    {
        private IEnumerable<IDispatchMessageInspector> _messageInspectors { get; set; }

        public UserEndpointWebHttpBehavior()
            : this(new List<IDispatchMessageInspector>())
        { }

        public UserEndpointWebHttpBehavior(IDispatchMessageInspector messageInspector)
            : this(new[] { messageInspector })
        { }

        public UserEndpointWebHttpBehavior(IEnumerable<IDispatchMessageInspector> messageInspectors)
        {
            _messageInspectors = messageInspectors;
        }

        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            foreach (var item in operationDescription.Messages[0].Body.Parts)
            {
                item.Type = typeof(string);
            }

            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }

        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            //if (_messageInspectors.Any())
            //    endpointDispatcher.AddMessageInspectors(_messageInspectors);

            //foreach (var operation in endpoint.Contract.Operations)
            //{
            //    if (operation.Behaviors.Contains(typeof(UserEndpointWebHttpGetOperationBehavior)))
            //        continue;

            //    operation.Behaviors.Add(new UserEndpointWebHttpGetOperationBehavior());
            //}

            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
        }
    }
}