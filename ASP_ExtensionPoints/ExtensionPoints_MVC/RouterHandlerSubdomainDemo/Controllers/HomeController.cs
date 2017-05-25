namespace RouterHandlerSubdomainDemo.Controllers
{
    using System.Web.Mvc;
    using Authentication;

    [SubdomainAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var subdomain = filterContext.RequestContext.RouteData.Values["subdomain"];
        }
    }
}