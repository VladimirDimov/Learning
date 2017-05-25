namespace FilterProviderDemo2.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class GlobalFilter1 : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(GlobalFilter1)} was called!");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}