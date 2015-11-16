using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WebHttpBehaviorExtensions;

namespace WcfRestAuthentication.Services.Api.Endpoints.Product
{
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{categoryId}?pageIndex={pageIndex}&pageSize={pageSize}"), UriTemplateSafe]
        IEnumerable<Model.Product> GetList(Guid categoryId, int pageIndex, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        Model.Product Put(Model.Product product);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{productId}"), UriTemplateSafe]
        Model.Product Get(Guid productId);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Model.Product Post(Model.Product product);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{productId}"), UriTemplateSafe]
        void Delete(Guid productId);
    }
}