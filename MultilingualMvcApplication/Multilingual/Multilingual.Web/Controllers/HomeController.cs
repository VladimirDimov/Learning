namespace Multilingual.Web.Controllers
{
    using System.Web.Mvc;
    using Multilingual.Web.MultilingualActivator;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var translationsResourceProvider = TranslationsResourceProvider.Instance("C:\\Users\\User3\\Desktop\\Learning\\MultilingualMvcApplication\\Multilingual\\Multilingual.Web\\Resources\\Translations.json", "en");


            translationsResourceProvider["About", "fr"] = "About FR";

            return View();
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
