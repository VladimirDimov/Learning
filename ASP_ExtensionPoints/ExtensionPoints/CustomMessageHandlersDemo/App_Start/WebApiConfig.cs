using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.ModelBinding;
using CustomMessageHandlersDemo.CustomMessageHandlers;
using CustomMessageHandlersDemo.Filters;

namespace CustomMessageHandlersDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{language}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, language = "en" }
            );

            config.Services.Replace(typeof(IHttpControllerSelector), new SetTHreadCultureControllerSelector(config));

            config.MessageHandlers.Add(new MyMessageHandler1());
            config.Filters.Add(new CustomAuthorizationFilter());

            // ((System.Net.Http.Formatting.BaseJsonMediaTypeFormatter)new System.Collections.Generic.Mscorlib_CollectionDebugView<System.Net.Http.Formatting.MediaTypeFormatter>(configuration.Formatters).Items[0]).SerializerSettings.Culture.UseUserOverride
            foreach (var item in config.Formatters)
            {
                var defaultCultureIdentifier = (item as BaseJsonMediaTypeFormatter)?.SerializerSettings?.Culture?.LCID;
                if (defaultCultureIdentifier.HasValue)
                {
                    ((System.Net.Http.Formatting.BaseJsonMediaTypeFormatter)item).SerializerSettings.Culture = new CultureInfo(defaultCultureIdentifier.Value, true);
                }
            }
        }
    }

    internal class SetTHreadCultureControllerSelector : DefaultHttpControllerSelector
    {
        public SetTHreadCultureControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //Get the {language} parameter in the RouteData
            var routeData = request.GetRouteData();
            string language = routeData.Values["language"] as string;

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;


            return base.SelectController(request);
        }
    }
}
