namespace RouteHandlerDemo
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using RouteHandlerDemo.RouteHandlers;
    using RouteHandlers.Redirect;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("api/{controller}/{action}/{id}");


            //routes.Add(new Route("ping", new PingRouteHandler()));

            //routes.MapRoute(
            //    name: "WithPrefix",
            //    url: "{prefix}/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    constraints: new { prefix = "api" }
            //);

            routes.Add(new Route("api", new RedirectRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}