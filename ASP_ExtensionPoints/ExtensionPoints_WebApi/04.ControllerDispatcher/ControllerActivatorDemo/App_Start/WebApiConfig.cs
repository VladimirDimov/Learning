namespace WebApiTest
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using WebApiTest.App_Start;

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

            var container = AutofacConfig.Register();

            config.Services.Replace(typeof(IHttpControllerActivator), new CustomControllerActivator(container));
        }
    }
}