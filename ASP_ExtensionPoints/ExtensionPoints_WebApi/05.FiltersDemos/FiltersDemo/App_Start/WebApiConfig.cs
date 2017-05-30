namespace ActionFIltersDemo
{
    using System.Web.Http;
    using ActionFIltersDemo.Filters;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new AuthenticationFilter1() { From = "Global" });
            config.Filters.Add(new GlobalFilter1());
            config.Filters.Add(new ExceptionFIlter1());

            config.MessageHandlers.Add(new ExceptionHandlerMessageHandler());
            config.MessageHandlers.Add(new CustomMessageHandler());
        }
    }
}