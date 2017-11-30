namespace ODataDynamicObjects.WebApi
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using ODataDynamicObjects.WebApi.Models;

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
                defaults: new { id = RouteParameter.Optional, controller = "DynamicModel" }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            builder.EntitySet<BaseModel>("DynamicModel");
            var route = config.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());

            config.MessageHandlers.Add(new ODataMessageHandler(builder, config));
        }

        public class ODataMessageHandler : DelegatingHandler
        {
            private readonly ODataModelBuilder builder;
            private readonly HttpConfiguration config;

            public ODataMessageHandler(ODataModelBuilder builder, HttpConfiguration config)
            {
                this.builder = builder;
                this.config = config;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                //builder.EntitySet<PersonModel>("PersonModel");
                //var route = config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());

                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}