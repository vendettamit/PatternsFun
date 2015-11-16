using System.Collections.Generic;
using System.ServiceModel.Dispatcher;

namespace WcfRestAuthentication.Extensions
{
    public static class EndpointDispatcherExtensions
    {
        public static void AddMessageInspectors(this EndpointDispatcher dispatcher,
            IEnumerable<IDispatchMessageInspector> dispatchMessageInspectors)
        {
            //Grab the message inspectors for each of the service endpoints
            var inspectorCollection = dispatcher.DispatchRuntime.MessageInspectors;

            //Add our authentication inspector
            foreach (var inspector in dispatchMessageInspectors)
            {
                //If the inspectors collection already contains this inspector, skip
                if (inspectorCollection.Contains(inspector))
                    return;

                inspectorCollection.Add(inspector);
            }

        }
    }
}