namespace WebApplication1
{
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using WebApplication1.Controllers;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            for (int i = 0; i < 5000; i++)
            {
                HomeController.peopleCollection.Add(new Person
                {
                    Id = i + 1,
                    Name = $"First{i + 1} Last{i + 1}",
                    Age = 10 + new Random().Next(0, 90),
                    Town = $"Town{i + 1}"
                });
            }
        }
    }
}