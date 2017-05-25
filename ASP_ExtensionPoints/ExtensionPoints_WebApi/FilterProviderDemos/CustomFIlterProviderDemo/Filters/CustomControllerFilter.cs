namespace CustomFIlterProviderDemo.Filters
{
    using System.Diagnostics;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class CustomControllerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.WriteLine(this.GetType().Name);

            base.OnActionExecuting(actionContext);
        }
    }
}