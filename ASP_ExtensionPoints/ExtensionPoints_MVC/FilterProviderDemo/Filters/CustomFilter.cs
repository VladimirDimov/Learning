namespace FilterProviderDemo.Filters
{
    using System.Web.Mvc;

    public class CustomFilterAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomFilterIsCalled = true;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}