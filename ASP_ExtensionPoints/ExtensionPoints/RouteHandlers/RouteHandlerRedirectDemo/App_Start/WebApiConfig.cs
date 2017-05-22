namespace RouteHandlerRedirectDemo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.Http.Routing;
    using System.Xml.Linq;
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
                defaults: new { id = RouteParameter.Optional, controller = "home" }
            );

            config.Routes.Add("NoPrefixRoute", new NoPrefixRoute(config));
        }

        public class NoPrefixRoute : IHttpRoute
        {
            private HttpConfiguration httpConfiguration;

            public NoPrefixRoute(HttpConfiguration httpConfiguration)
            {
                this.httpConfiguration = httpConfiguration;
            }

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
                    return new Dictionary<string, object>
                    {
                        { "controller", "home" }
                    };
                }
            }

            public HttpMessageHandler Handler
            {
                get
                {
                    return new MyMessageHandler(httpConfiguration);
                }
            }

            public string RouteTemplate
            {
                get
                {
                    return "{controller}/{id}";
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

        public class MyMessageHandler : DelegatingHandler
        {
            public MyMessageHandler(HttpConfiguration httpConfiguration)
            {
                InnerHandler = new HttpControllerDispatcher(httpConfiguration);
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var url = request.RequestUri.Scheme + "://" + request.RequestUri.Authority + "/api" + request.RequestUri.PathAndQuery;
                var response = request.CreateResponse(System.Net.HttpStatusCode.Redirect);

                return Task.Factory.StartNew(() =>
                {
                    response.Headers.Location = new Uri(url);
                    return response;
                });
            }
        }
    }
}