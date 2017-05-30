using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActionInjectionDemo.Services;
using Autofac;
using Autofac.Integration.WebApi;

namespace ActionInjectionDemo
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MyService>().As<IMyService>();
            var container = containerBuilder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
