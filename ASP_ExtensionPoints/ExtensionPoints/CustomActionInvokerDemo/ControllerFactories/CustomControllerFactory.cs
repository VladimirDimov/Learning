namespace CustomActionInvokerDemo.ControllerFactories
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using CustomActionInvokerDemo.ActionInvokers;

    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName) as Controller;
            controller.ActionInvoker = new FilterPriorityActionInvoker();

            return controller;
        }
    }
}