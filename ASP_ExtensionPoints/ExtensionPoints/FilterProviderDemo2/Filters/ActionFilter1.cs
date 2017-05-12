namespace FilterProviderDemo2.Filters
{
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;

    public class ActionFilter1 : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine($"{nameof(ActionFilter1)} was called!");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}