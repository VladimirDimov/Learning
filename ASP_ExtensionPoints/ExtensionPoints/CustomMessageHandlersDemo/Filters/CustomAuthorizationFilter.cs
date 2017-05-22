namespace CustomMessageHandlersDemo.Filters
{
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class CustomAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ////Get the {language} parameter in the RouteData
            //var routeData = actionContext.Request.GetRouteData();
            //string language = routeData.Values["language"] as string;

            ////Get the culture info of the language code
            //CultureInfo culture = CultureInfo.GetCultureInfo(language);
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;

            base.OnActionExecuting(actionContext);
        }
    }
}