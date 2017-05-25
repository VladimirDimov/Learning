namespace HttpParameterBindingDemo
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using HttpParameterBindingDemo.ModelBinding;
    using HttpParameterBindingDemo.Models;

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

            config.ParameterBindingRules.Insert(0, (paramDesc) =>
            {
                if (typeof(BaseModel).IsAssignableFrom(paramDesc.ParameterType))
                {
                    return new BaseModelParamBinding(paramDesc);
                }

                // any other types, let the default parameter binding handle
                return null;
            });
        }
    }
}