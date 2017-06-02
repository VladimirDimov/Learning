namespace RedirectDemo
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { controller = "^(?!.*?api).*" }
            );

            config.Routes.MapHttpRoute(
                name: "RedirectRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new RedirectToApiMessageHandler()
            );

            //config.Routes.Add(nameof(RedirectToApiRoute), new RedirectToApiRoute());
        }
    }
}