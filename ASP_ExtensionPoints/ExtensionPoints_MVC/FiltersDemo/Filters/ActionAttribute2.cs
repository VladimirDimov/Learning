namespace FiltersDemo.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ActionAttribute2 : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(ActionAttribute2)}-{nameof(OnActionExecuted)}");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine($"{nameof(ActionAttribute2)}-{nameof(OnActionExecuting)}");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine($"{nameof(ActionAttribute2)}-{nameof(OnResultExecuting)}");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(ActionAttribute2)}-{nameof(OnResultExecuted)}");
        }

    }
}