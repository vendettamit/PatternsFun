using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace WcfRestAuthentication.Services.Api
{
    public class RestAuthenticationManager : ServiceAuthenticationManager
    {
        public override ReadOnlyCollection<IAuthorizationPolicy> Authenticate(ReadOnlyCollection<IAuthorizationPolicy> authPolicy, Uri listenUri, ref Message message)
        {
            var requestProperties =
                (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];

            var rawAuthHeader = requestProperties.Headers["Authorization"];

            AuthenticationHeader authHeader = null;
            if (AuthenticationHeader.TryDecode(rawAuthHeader, out authHeader));
            {
                var identity = new GenericIdentity(authHeader.Username);
                var principal = new GenericPrincipal(identity, new string[] { });

                var httpContext = new HttpContextWrapper(HttpContext.Current)
                {
                    User = principal,
                };

                if (httpContext.User != null)
                    return authPolicy;
            }

            SendUnauthorizedResponse();

            return base.Authenticate(authPolicy, listenUri, ref message);
        }

        private void SendUnauthorizedResponse()
        {
            HttpContext.Current.Response.StatusCode = 401;
            HttpContext.Current.Response.StatusDescription = "Unauthorized";
            HttpContext.Current.Response.Headers.Add("WWW-Authenticate", string.Format("{0} realm=\"{1}\"", "Basic", "site"));
            HttpContext.Current.Response.End();
        }
    }
}