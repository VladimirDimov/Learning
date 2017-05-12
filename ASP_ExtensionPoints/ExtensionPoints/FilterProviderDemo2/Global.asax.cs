namespace FilterProviderDemo2
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using FilterProviderDemo2.Filters;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterFilters();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterFilters()
        {
            //FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new CustomFilterProvider());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}