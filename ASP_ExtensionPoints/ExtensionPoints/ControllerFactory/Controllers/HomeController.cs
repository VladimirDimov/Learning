using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerFactory.Filters;

namespace ControllerFactory.Controllers
{
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

        public ActionResult TestDate()
        {
            return this.View(nameof(this.TestDate));
        }

        [HttpPost]
        [SetCulture]
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
    }
}