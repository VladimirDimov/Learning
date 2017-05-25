namespace FiltersDemo.Filters
{
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ControllerAttribute1 : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(ControllerAttribute1)}-{nameof(OnActionExecuted)}");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine($"{nameof(ControllerAttribute1)}-{nameof(OnActionExecuting)}");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine($"{nameof(ControllerAttribute1)}-{nameof(OnResultExecuting)}");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(ControllerAttribute1)}-{nameof(OnResultExecuted)}");
        }
    }
}