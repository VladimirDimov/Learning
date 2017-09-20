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

            config.ParameterBindingRules.Insert(0, (parameterDescriptor) =>
            {
                if (typeof(BaseModel).IsAssignableFrom(parameterDescriptor.ParameterType))
                {
                    return new BaseModelParamBinding(parameterDescriptor);
                }

                // any other types, let the default parameter binding handle
                return null;
            });
        }
    }
}