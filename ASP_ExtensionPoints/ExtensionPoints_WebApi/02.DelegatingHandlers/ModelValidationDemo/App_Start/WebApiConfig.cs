namespace ModelValidationDemo
{
    using System.Web.Http;
    using ModelValidationDemo.Filters;
    using ModelValidationDemo.ResponseHandler;

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

            config.MessageHandlers.Add(new ResponseWrappingHandler());
            config.Filters.Add(new ModelStateValidationFilter());
        }
    }
}