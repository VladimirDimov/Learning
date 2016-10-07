namespace Multilingual.Web.MultilingualActivator
{
    using System.Threading;
    using System.Web.Mvc;

    public static class TranslateExtensionMethods
    {
        public static TranslationsResourceProvider TranslationsDictionary { get; set; }

        public static string Translate(this HtmlHelper htmlHelper, string key)
        {
            var language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            return TranslationsDictionary[key, language];

            //var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(TranslationsDictionary[key]);
            //var translation = jsonObject[language];

            //return translation;
        }
    }
}
