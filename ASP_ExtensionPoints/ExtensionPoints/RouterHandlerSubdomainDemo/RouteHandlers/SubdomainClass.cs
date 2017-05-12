namespace RouterHandlerSubdomainDemo.RouteHandlers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class SubdomainRouteHandler : RouteBase
    {
        private string defaultController;
        private string defaultAction;

        public SubdomainRouteHandler(string defaultController, string defaultAction)
        {
            this.defaultController = defaultController;
            this.defaultAction = defaultAction;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request?.Url == null)
            {
                return null;
            }

            var host = httpContext.Request.Url.Host;
            var index = host.IndexOf('.');
            if (index < 0)
            {
                throw new HttpException(404, "Missing subdomain.");
            }

            var subdomain = host.Substring(0, index);

            if (!this.IsValidateSubdomain(subdomain))
            {
                throw new HttpException(404, $"Invalid subdomain: {subdomain}");
            }

            string[] segments = httpContext.Request.Url.PathAndQuery
                .TrimStart('/')
                .Split('/');

            string controller = (segments.Length > 1) ? segments[0] : this.defaultController;
            string action = (segments.Length > 2) ? segments[1] : this.defaultAction;

            var routeData = new RouteData(this, new MvcRouteHandler());
            routeData.Values.Add("controller", controller); //Goes to the relevant Controller  class
            routeData.Values.Add("action", action); //Goes to the relevant action method on the specified Controller
            routeData.Values.Add("subdomain", subdomain); //pass subdomain as argument to action method
            return routeData;
        }

        private bool IsValidateSubdomain(string subdomain)
        {
            if (subdomain == null || subdomain == string.Empty)
            {
                return false;
            }

            var validSubdomains = new string[] { "subdomain-1", "subdomain-2", "subdomain-3" }.Select(x => x.ToLower());
            if (validSubdomains.Contains(subdomain.ToLower()))
            {
                return true;
            }

            return false;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            //Implement your formating Url formating here
            return null;
        }
    }
}