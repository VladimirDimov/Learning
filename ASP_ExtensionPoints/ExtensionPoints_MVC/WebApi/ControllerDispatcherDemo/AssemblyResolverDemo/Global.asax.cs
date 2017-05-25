namespace AssemblyResolverDemo
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}