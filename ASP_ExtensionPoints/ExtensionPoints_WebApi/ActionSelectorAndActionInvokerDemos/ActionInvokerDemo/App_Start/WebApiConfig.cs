using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using WebApi.CustomActionInvokerDemo.ActionInvokers;
using WebApi.CustomActionInvokerDemo.Filters;

namespace WebApi.CustomActionInvokerDemo
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

            var services = config.Services;

            config.Services.Replace(typeof(IHttpActionInvoker), new CustomActionInvoker());
            //config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            config.Filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
