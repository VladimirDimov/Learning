namespace Multilingual.Web.MultilingualActivator
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class LocalizedControllerActivator : IControllerActivator
    {
        private const string Language = "Language";

        private string defaultLanguage = "en";

        public void ChangeLang(RequestContext requestContext, string langAbbreviation)
        {
            var languageCookie = new HttpCookie(Language, langAbbreviation);
            requestContext.HttpContext.Response.Cookies.Add(languageCookie);
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            string lang =
                        (string)requestContext.RouteData.Values["lang"] ??
                        requestContext.HttpContext.Request.Cookies["Language"].Value ??
                        defaultLanguage;

            if (lang != defaultLanguage)
            {
                try
                {
                    var culture = new CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = culture; // No need if we record the translations in json format
                    Thread.CurrentThread.CurrentCulture = culture;
                }
                catch (Exception)
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
