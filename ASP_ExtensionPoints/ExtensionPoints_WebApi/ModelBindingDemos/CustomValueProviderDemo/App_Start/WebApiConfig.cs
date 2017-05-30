﻿namespace CustomValueProviderDemo
{
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using CustomValueProviderDemo.App_Start;

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

            config.Services.Add(typeof(ValueProviderFactory), new CookieValueProviderFactory());
        }
    }
}