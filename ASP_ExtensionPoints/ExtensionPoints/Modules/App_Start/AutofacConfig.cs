using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Modules.ActionInvokers;
using Modules.Filters;

namespace Modules.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container { get; set; }

        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //// OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            //// OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            //// OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            //// OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            // Register services
            RegisterCommon(builder);
            //RegisterServices(builder);
            //RegisterLibraries(builder);
            //RegisterDatabase(builder);
            //RegisterFilters(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            Container = container;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterFilters(ContainerBuilder builder)
        {
        }

        private static void RegisterCommon(ContainerBuilder builder)
        {
            builder.RegisterType<HomeActionInvoker>().As<IActionInvoker>();
            builder.RegisterType<AuthRepo>().As<IAuthRepo>();
            //builder.RegisterFilterProvider();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
        }

        private static void RegisterLibraries(ContainerBuilder builder)
        {
        }

        private static void RegisterDatabase(ContainerBuilder builder)
        {
        }
    }
}
