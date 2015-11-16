using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using WebHttpBehaviorExtensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.User
{
   [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{UserId}"), UriTemplateSafe]
        Model.User Get(Guid userId);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Model.User Post(Model.User user);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        Model.User Put(Model.User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{UserId}"), UriTemplateSafe]
        void Delete(Guid userId);

    }
}
