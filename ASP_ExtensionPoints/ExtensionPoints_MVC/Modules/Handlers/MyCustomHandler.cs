using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Modules.Handlers
{
    public class MyCustomHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            Debug.WriteLine("MyCustomHandler");
        }
    }
}