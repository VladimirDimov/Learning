namespace MvcRequestEntryPoints.Web.Controllers
{
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        // Runs before execution of Action method.
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        // Runs after execution of Action method.
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        // Runs before content is rendered to View.
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        // Runs after content is rendered to view.
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}