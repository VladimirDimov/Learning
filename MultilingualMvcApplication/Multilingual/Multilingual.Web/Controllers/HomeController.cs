namespace Multilingual.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using DataTables;
    using Models;
    using Multilingual.Web.MultilingualActivator;
    using System.Net;

    public class HomeController : Controller
    {
        string path = @"C:\Users\vladko_sz\Desktop\Learning\MultilingualMvcApplication\Multilingual\Multilingual.Web\Resources\Translations.json";

        public ActionResult Index()
        {
            return View();
        }

        [DataTable]
        public ActionResult GetTranslations()
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance(path, "en");

            var translations = new List<TranslationModel>();
            foreach (var title in translationsResourceProvider.Translations.Keys)
            {
                translations.Add(new TranslationModel
                {
                    Title = title,
                    Translations = translationsResourceProvider.Translations[title]
                });
            }

            return View(translations.AsQueryable());
        }

        public ActionResult AddTranslation(string title)
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance(path, "en");
            translationsResourceProvider.AddTranslation(title);

            return new HttpStatusCodeResult(200);
        }

        public ActionResult UpdateTranslation(string title, string language, string translation)
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance(path, "en");
            translationsResourceProvider[title, language] = translation;

            return new HttpStatusCodeResult(200);
        }

        public ActionResult RemoveTranslation(string title, string language)
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance(path, "en");
            translationsResourceProvider.Delete(title, language);

            return new HttpStatusCodeResult(200);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
