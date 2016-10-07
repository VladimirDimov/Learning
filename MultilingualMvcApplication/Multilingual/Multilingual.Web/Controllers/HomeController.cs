namespace Multilingual.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using DataTables;
    using Models;
    using Multilingual.Web.MultilingualActivator;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [DataTable]
        public ActionResult GetTranslations()
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance("C:\\Users\\User3\\Desktop\\Learning\\MultilingualMvcApplication\\Multilingual\\Multilingual.Web\\Resources\\Translations.json", "en");

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
