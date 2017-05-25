namespace RouterHandlerSubdomainDemo.Authentication
{
    using System.Web.Mvc;

    public class SubdomainAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var subdomain = filterContext.RequestContext.RouteData.Values["subdomain"];
            // Put some authentication logic here
        }
    }
}