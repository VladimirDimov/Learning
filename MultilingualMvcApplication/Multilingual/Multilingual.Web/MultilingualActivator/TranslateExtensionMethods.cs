namespace Multilingual.Web.MultilingualActivator
{
    using System.Threading;
    using System.Web.Mvc;

    public static class TranslateExtensionMethods
    {
        // This property must be set on application start!
        public static TranslationsResourceProvider TranslationsDictionary { get; set; }

        public static string Translate(this HtmlHelper htmlHelper, string key)
        {
            var language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            return TranslationsDictionary[key, language];
        }
    }
}
