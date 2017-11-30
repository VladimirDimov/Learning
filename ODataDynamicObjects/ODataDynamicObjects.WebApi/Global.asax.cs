namespace ODataDynamicObjects.WebApi
{
    using System.Web.Http;
    using System.Web.OData.Extensions;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.EnableDependencyInjection();
        }
    }
}