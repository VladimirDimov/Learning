namespace FiltersDemo.Controllers
{
    using System.Diagnostics;
    using System.Web.Mvc;
    using FiltersDemo.Filters;

    [ControllerAttribute1()]
    [ControllerAttribute2]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ActionAttribute1]
        [ActionAttribute2()]
        [AuthorizationFilterB]
        [AuthorizationFilterA]
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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("HomeController OnActionExecuting");
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("HomeController OnActionExecuted");
        }
    }
}