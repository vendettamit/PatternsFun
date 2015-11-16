using System.ServiceModel;
using System.Threading;

namespace WcfRestAuthentication.Services.Api
{
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] =
                Thread.CurrentPrincipal;

            return base.CheckAccessCore(operationContext);
        }
    }
}