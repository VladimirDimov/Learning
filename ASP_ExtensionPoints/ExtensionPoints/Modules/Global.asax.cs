namespace Modules
{
    using System.Diagnostics;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using ControllerFactory;
    using FIlterProviders;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.Register();

            FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new CustomFilterProvider());

            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));
        }

        protected void Application_End()
        {
            Debug.WriteLine("Application end");
        }
    }
}