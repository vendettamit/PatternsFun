using System;
using System.Web.Routing;
using System.ServiceModel.Activation;
using WcfRestAuthentication.Services.Api;

namespace WcfRestAuthentication
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MapRoutes(RouteTable.Routes);

        }

        private void MapRoutes(RouteCollection routes)
        {
            routes.Add(new ServiceRoute("api", new ServiceHostFactory(), typeof(ApiService)));
        }
    }
}