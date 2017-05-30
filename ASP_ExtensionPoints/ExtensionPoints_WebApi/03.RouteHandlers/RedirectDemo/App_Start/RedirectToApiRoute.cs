using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace RedirectDemo
{
    internal class RedirectToApiRoute : IHttpRoute
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
                return new RedirectToApiMessageHandler();
            }
        }

        public string RouteTemplate
        {
            get
            {
                return "api/{controller}/{id}";
            }
        }

        public IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            return new HttpRouteData(this);
        }

        public IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values)
        {
            throw new NotImplementedException();
        }
    }
}