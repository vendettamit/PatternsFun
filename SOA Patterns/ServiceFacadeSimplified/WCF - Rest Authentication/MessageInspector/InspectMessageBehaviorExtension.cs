using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace WcfRestAuthentication.MessageInspector
{
    public class InspectMessageBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(InsepctMessageBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new InsepctMessageBehavior();
        }
    }
}