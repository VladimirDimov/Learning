using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcApp.CustomHandlers
{
    public class MyHandler : IHttpHandler
    {
        public MyHandler()
        {

        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            Debug.WriteLine($"This is {nameof(MyHandler)}");
        }
    }
}