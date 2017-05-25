namespace RouteHandlerDemo.RouteHandlers
{
    using System.Web;
    using System.Web.Routing;

    public class PingRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new PingHttpHandler();
        }
    }
}