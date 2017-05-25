namespace Modules.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;
    using ActionInvokers;
    using App_Start;
    using Filters;

    [SetCulture]
    [CustomAuthorization()]
    public class HomeController : Controller
    {
        private static int number = 0;

        public HomeController()
        {
            //this.ActionInvoker = new HomeActionInvoker();
        }

        public ActionResult Index()
        {
            this.ViewBag.Language = Thread.CurrentThread.CurrentCulture.DisplayName;
            this.ViewBag.Number = ++number;

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

        public ActionResult TestDate()
        {
            return this.View(nameof(this.TestDate));
        }

        [HttpPost]
        public ActionResult TestDate(DateTime date)
        {
            var isvalid = this.ModelState.IsValid;

            var formats = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .ToDictionary(x => x.Name, x => x.DateTimeFormat.GetAllDateTimePatterns());

            ViewBag.Month = date.Month;
            ViewBag.Day = date.Day;
            ViewBag.Year = date.Year;

            return this.View(nameof(this.TestDate));
        }

        [TestMethodSelector(false)]
        public ActionResult TestActionInvoker()
        {
            return this.View();
        }

        [TestMethodSelector(true)]
        public ActionResult TestActionInvoker(string test)
        {
            this.ViewBag.Test = test;

            return this.View();
        }
    }
}