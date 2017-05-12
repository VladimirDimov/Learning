namespace CustomActionInvokerDemo.Controllers
{
    using System.Web.Mvc;
    using CustomActionInvokerDemo.Filters;

    [FilterAttribute1]
    public class HomeController : Controller
    {
        [FilterAttribute2]
        public ActionResult Index()
        {
            return View();
        }

        [FilterAttribute2]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [FilterAttribute2]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}