using Rest.Interfaces;
using Rest.Services;
using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Rest.Filters
{
    public class BasicHttpAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly IDbService _dbService;

        static BasicHttpAuthorizeAttribute()
        {
            if (_dbService == null)
                _dbService = new DbService();
        }

        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            try
            {
                // Get the header value
                AuthenticationHeaderValue auth = actionContext.Request.Headers.Authorization;
                // ensure its schema is correct
                if (auth != null && string.Compare(auth.Scheme, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    // get the credientials
                    string credentials = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(auth.Parameter));
                    int separatorIndex = credentials.IndexOf(':');
                    if (separatorIndex >= 0)
                    {
                        // get user and password
                        string username = credentials.Substring(0, separatorIndex);
                        string password = credentials.Substring(separatorIndex + 1);

                        if (string.IsNullOrEmpty(username) == false && string.IsNullOrEmpty(password) == false)
                        {
                            var user = await _dbService.GetUserByPhoneAsync(username).ConfigureAwait(false);
                            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                                Thread.CurrentPrincipal = actionContext.ControllerContext.RequestContext.Principal = new GenericPrincipal(
                                    new AppGenericIdentity(username, "Basic", user), new string[] { });
                        }
                    }
                }
            }
            catch { }
            await base.OnAuthorizationAsync(actionContext, cancellationToken);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }
    }
}