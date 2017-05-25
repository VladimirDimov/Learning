namespace CustomControllerSelectorDemo.App_Start
{
    using System;
    using System.Linq;
    using System.Web.Http.Controllers;

    public class CustomActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            try
            {
                var actionSDescriptor = base.SelectAction(controllerContext);

                return actionSDescriptor;
            }
            catch (Exception ex)
            {
                var controllerType = controllerContext.ControllerDescriptor.ControllerType;
                var actionName = controllerContext.Request.RequestUri.Segments.Last().ToLower();
                var actions = controllerContext.ControllerDescriptor.ControllerType.GetMethods().Where(x => x.IsPublic);
                var methodInfoCollection = actions.Where(x => x.Name.ToLower() == actionName && x.IsPublic);

                if (methodInfoCollection.Count() != 1)
                {
                    throw ex;
                }

                return new ReflectedHttpActionDescriptor(
                    controllerContext.ControllerDescriptor,
                    methodInfoCollection.First());
            }
        }
    }
}