namespace Modules.ActionInvokers
{
    using System.Reflection;
    using System.Web.Mvc;

    public class TestMethodSelector : ActionMethodSelectorAttribute
    {
        private bool useTestParam;

        public TestMethodSelector(bool useTestParam)
        {
            this.useTestParam = useTestParam;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var testParam = controllerContext.RequestContext.HttpContext.Request.QueryString["test"];
            if (useTestParam && testParam != null)
            {
                return true;
            }
            else if (!useTestParam && testParam == null)
            {
                return true;
            }

            return false;
        }
    }
}