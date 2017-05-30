namespace WebApiTest.App_Start
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using Autofac;

    public class CustomControllerActivator : IHttpControllerActivator
    {
        private IContainer container;

        public CustomControllerActivator(IContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = container.Resolve(controllerType) as IHttpController;

            return controller;
        }
    }
}