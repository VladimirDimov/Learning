namespace Modules.Modules
{
    using System;
    using System.Diagnostics;
    using System.Web;

    public class MyCustomModule : IHttpModule
    {
        public static int beginrequest = 0;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.BeginRequest;
            context.AuthenticateRequest += (s, a) =>
            {
                Debug.WriteLine("AuthenticateRequest" + " " + ++beginrequest + " " +
                        context.Request.Url.AbsolutePath);
            };
        }

        public void BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            Debug.WriteLine("BeginRequest" + " " + ++beginrequest + " " +
                    context.Request.Url.AbsolutePath);
        }
    }
}