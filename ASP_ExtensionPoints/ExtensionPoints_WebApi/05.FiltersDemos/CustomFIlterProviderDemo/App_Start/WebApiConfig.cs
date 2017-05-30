namespace CustomFIlterProviderDemo
{
    using System.Web.Http;
    using System.Web.Http.Filters;
    using CustomFIlterProviderDemo.FilterProviders;

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

            config.Services.Replace(typeof(IFilterProvider), new CustomFilterProvider(new ActionDescriptorFilterProvider()));
        }
    }
}