using System;
using System.ServiceModel.Configuration;

namespace WcfRestAuthentication.Services.Api.Endpoints.User.V1.Behaviors
{
    public class UserEndpointWebHttpBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(UserEndpointWebHttpBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new UserEndpointWebHttpBehavior();
        }
    }
}