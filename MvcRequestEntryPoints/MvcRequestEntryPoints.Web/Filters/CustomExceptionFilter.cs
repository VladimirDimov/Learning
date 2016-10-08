namespace MvcRequestEntryPoints.Web.Filters
{
    using System.Web.Mvc;

    public class CustomExceptionFilter : ActionFilterAttribute, IExceptionFilter // or inherrit HandleErrorAttribute
    {
        public void OnException(ExceptionContext filterContext)
        {
            // Do something
        }
    }
}
