namespace FiltersDemo.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class GlobalFilter1 : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(GlobalFilter1)}-{nameof(OnActionExecuted)}");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine($"{nameof(GlobalFilter1)}-{nameof(OnActionExecuting)}");
        }
    }
}