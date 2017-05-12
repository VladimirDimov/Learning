namespace RouteHandlerDemo.RouteHandlers.Redirect
{
    using System;
    using System.Web;
    using System.Web.Routing;

    public class RedirectRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new RedirectHttpHandler();
        }
    }
}