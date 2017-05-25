namespace WebApi.RouteHandlers.CustomHttpMessage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using System.Xml.Serialization;

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
                defaults: new { id = RouteParameter.Optional, controller = "Home" }
            );

            config.Routes.Add(nameof(PingRoute), new PingRoute());
        }

        public class PingRoute : IHttpRoute
        {
            public IDictionary<string, object> Constraints
            {
                get
                {
                    return null;
                }
            }

            public IDictionary<string, object> DataTokens
            {
                get
                {
                    return null;
                }
            }

            public IDictionary<string, object> Defaults
            {
                get
                {
                    return null;
                }
            }

            public HttpMessageHandler Handler
            {
                get
                {
                    return new MyMessageHandler();
                }
            }

            public string RouteTemplate
            {
                get
                {
                    return "Ping";
                }
            }

            public IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
            {
                return new HttpRouteData(new HttpRoute(this.RouteTemplate, this.Defaults as HttpRouteValueDictionary, this.Constraints as HttpRouteValueDictionary, this.DataTokens as HttpRouteValueDictionary, this.Handler));
            }

            public IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values)
            {
                throw new NotImplementedException();
            }
        }

        public class MyMessageHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.Factory.StartNew<HttpResponseMessage>(() =>
                {
                    using (var writer = new StringWriter())
                    {
                        var xmlSerializer = new XmlSerializer(typeof(PingResult));
                        var result = new PingResult
                        {
                            ApplicationName = "MyApplication",
                            Version = "0.0.0.1"
                        };

                        xmlSerializer.Serialize(writer, result);

                        return new HttpResponseMessage
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,
                            Content = new ObjectContent(typeof(PingResult), result, GlobalConfiguration.Configuration.Formatters.XmlFormatter)
                        };
                    }
                });
            }
        }

        public class PingResult
        {
            [XmlElement]
            public string ApplicationName { get; set; }

            [XmlElement]
            public string Version { get; set; }
        }
    }
}