using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WcfRestAuthentication.MessageInspector
{
    public class InsepctMessageBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new IncomingMessageLogger());
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}