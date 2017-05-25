namespace Modules.ActionInvokers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using App_Start;
    using Autofac;

    public class HomeActionInvoker : ControllerActionInvoker
    {
        private IContainer container;

        public HomeActionInvoker()
        {
            this.container = AutofacConfig.Container;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(
            ControllerContext controllerContext,
            IList<IActionFilter> filters,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            foreach (var filter in filters)
            {
                container.InjectProperties(filter);
            }

            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }

        protected override AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor)
        {
            foreach (var filter in filters)
            {
                container.InjectProperties(filter);
            }

            return base.InvokeAuthorizationFilters(controllerContext, filters, actionDescriptor);
        }
    }
}