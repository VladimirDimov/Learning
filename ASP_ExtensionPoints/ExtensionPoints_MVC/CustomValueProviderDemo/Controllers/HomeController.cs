namespace CustomValueProviderDemo.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        private const string SomeInformationKey = "SomeInformation";

        public ActionResult Index()
        {
            this.Session[SomeInformationKey] = "Some information in the seession.";

            return View();
        }

        public ActionResult About(string someInformation)
        {
            ViewBag.Message = someInformation;

            return View();
        }

        public ActionResult Contact(MyViewModel model)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}