namespace Modules.Filters
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class SetCultureAttribute : ActionFilterAttribute
    {
        public IAuthRepo AuthRepo { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Get the {language} parameter in the RouteData
            string language = filterContext.HttpContext.Request.Cookies["language"].Value;

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}