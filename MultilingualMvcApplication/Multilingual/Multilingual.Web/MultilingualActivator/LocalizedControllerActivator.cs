namespace Multilingual.Web.MultilingualActivator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Newtonsoft.Json;
    public class LocalizedControllerActivator : IControllerActivator
    {
        private const string Language = "Language";

        private string defaultLanguage = "en";

        static LocalizedControllerActivator()
        {
            TranslateExtensionMethods.TranslationsDictionary = 
                TranslationsResourceProvider
                .Instance(@"C:\Users\vladko_sz\Desktop\Learning\MultilingualMvcApplication\Multilingual\Multilingual.Web\Resources\Translations.json", "en");
        }

        public void ChangeLang(RequestContext requestContext, string langAbbreviation)
        {
            var languageCookie = new HttpCookie(Language, langAbbreviation);
            requestContext.HttpContext.Response.Cookies.Add(languageCookie);
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var cookieLanguage = requestContext.HttpContext.Request.Cookies["Language"]?.Value;
            string lang = (string)requestContext.RouteData.Values["lang"] ?? cookieLanguage ?? defaultLanguage;
            // Update the cookie language if needed
            if (lang != cookieLanguage)
            {
                ChangeLang(requestContext, lang);
            }

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
