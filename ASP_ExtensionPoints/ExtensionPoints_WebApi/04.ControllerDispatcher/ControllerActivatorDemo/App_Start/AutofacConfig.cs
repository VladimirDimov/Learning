namespace WebApiTest.App_Start
{
    using System.Linq;
    using Autofac;
    using WebApiTest.Controllers;
    using WebApiTest.Repositories;

    public class AutofacConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IPeopleRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();

            builder.RegisterTypes(typeof(HomeController).Assembly.GetTypes());

            var container = builder.Build();

            return container;
        }
    }
}