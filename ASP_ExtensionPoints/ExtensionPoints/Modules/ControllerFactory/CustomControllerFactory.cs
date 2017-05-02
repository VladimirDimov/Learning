namespace Modules.ControllerFactory
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            //Get the {language} parameter in the RouteData
            string language = requestContext.RouteData.Values["language"] == null ?
                "tr" : requestContext.RouteData.Values["language"].ToString();
            //string language = requestContext.HttpContext.Request.Cookies["language"].Value;

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var controller = base.CreateController(requestContext, controllerName);

            return controller;
        }
    }
}