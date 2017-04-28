using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcApp.CustomModules
{
    public class MyModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.OnBeginRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            var uri = HttpContext.Current.Request.Url.AbsoluteUri;
            Debug.WriteLine(uri);
            Debug.WriteLine($"This is {nameof(MyModule)}");
        }
    }
}