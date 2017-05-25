using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilterProviderDemo2.Filters;

namespace FilterProviderDemo2.Controllers
{
    public class HomeController : Controller
    {
        [SkipGlobalActionFilters]
        [ActionFilter1]
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
    }
}