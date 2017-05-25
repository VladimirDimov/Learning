namespace ControllerTypeResolverDemo
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using ControllerTypeResolverDemo.App_Start;
    using ControllerTypeResolverDemo.Controllers;

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

            config.Services.Replace(typeof(IHttpControllerTypeResolver), new MyControllerTypeResolver(typeof(BaseController)));
        }
    }
}