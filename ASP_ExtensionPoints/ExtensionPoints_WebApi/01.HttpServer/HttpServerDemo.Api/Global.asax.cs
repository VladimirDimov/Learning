namespace HttpServerDemo.Api
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            return config;
        }
    }
}