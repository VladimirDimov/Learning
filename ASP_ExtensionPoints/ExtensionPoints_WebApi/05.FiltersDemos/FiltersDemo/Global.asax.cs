namespace ActionFIltersDemo
{
    using System;
    using System.Diagnostics;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public override void Init()
        {
            this.AuthenticateRequest += this.OnAuthentication;
            this.AuthorizeRequest += this.OnAuthorization;
            this.Error += OnError;
        }

        private void OnError(object sender, EventArgs e)
        {
            Trace.WriteLine($"{this.GetType().Name} on error is executing.");
        }

        private void OnAuthorization(object sender, EventArgs e)
        {
            Trace.WriteLine($"{this.GetType().Name} on authorization is executing.");
        }

        private void OnAuthentication(object sender, EventArgs e)
        {
            Trace.WriteLine($"{this.GetType().Name} on authentication is executing.");
        }
    }
}