namespace CsvMediaTypeFormatterDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using CsvMediaTypeFormatterDemo.App_Start;
    using CsvMediaTypeFormatterDemo.Models;

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

            config.Formatters.Add(new CsvMediaTypeFormatter<Person>());
            config.Formatters.Add(new CsvMediaTypeFormatter<Car>());
        }
    }
}
