namespace CustomActionInvokerDemo.Filters
{
    using System.Web.Mvc;

    public class BaseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(this.GetType().Name);
        }
    }
}