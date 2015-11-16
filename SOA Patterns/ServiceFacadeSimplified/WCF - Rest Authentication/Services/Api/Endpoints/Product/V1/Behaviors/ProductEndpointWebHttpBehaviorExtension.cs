using System;
using System.ServiceModel.Configuration;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product.V1.Behaviors
{
    public class ProductEndpointWebHttpBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ProductEndpointWebHttpBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ProductEndpointWebHttpBehavior();
        }
    }
}