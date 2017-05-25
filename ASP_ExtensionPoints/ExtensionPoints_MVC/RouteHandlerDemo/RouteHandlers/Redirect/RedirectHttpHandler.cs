using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteHandlerDemo.RouteHandlers.Redirect
{
    public class RedirectHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var incomingPath = context.Request.Path;
            var redirectPath = incomingPath.Substring(4);
            context.Response.Redirect(redirectPath);
        }
    }
}