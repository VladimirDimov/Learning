namespace WcfAutofac
{
    using System;
    using System.Reflection;
    using Autofac;
    using WcfAutofac.BL;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.Register(c => new SomeRepository()).As<ISomeRepository>();
            builder.Register(c => new Service1(c.Resolve<ISomeRepository>())).Named<object>(typeof(IService1).FullName);

            Autofac.Integration.Wcf.AutofacHostFactory.Container = builder.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}