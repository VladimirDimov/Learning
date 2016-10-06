namespace Multilingual.Web.MultilingualActivator
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public static class TranslateExtensionMethods
    {
        public static string Translate(this HtmlHelper htmlHelper, string translations)
        {
            var language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(translations);
            var translation = jsonObject[language];

            return translation;
        }
    }
}
