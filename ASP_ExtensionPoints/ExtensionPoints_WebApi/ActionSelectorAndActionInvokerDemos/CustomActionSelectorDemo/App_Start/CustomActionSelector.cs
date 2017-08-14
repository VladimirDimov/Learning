namespace CustomActionSelectorDemo.App_Start
{
    using System.Linq;
    using System.Web;
    using System.Web.Http.Controllers;
    using Controllers;

    public class CustomActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var action = base.SelectAction(controllerContext);
            var methodInfo = ((ReflectedHttpActionDescriptor)action).MethodInfo;
            var isHidden = methodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(GoneAttribute));

            if (isHidden)
            {
                throw new HttpException(410, $"The resource {controllerContext.Request.RequestUri.AbsoluteUri} has been removed.");
            }

            return action;
        }
    }
}