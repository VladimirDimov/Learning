using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MethodSelectorDemo.ActionInvokers;

namespace MethodSelectorDemo.Controllers
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

        [OverloadSelector]
        public ActionResult Overload()
        {
            return this.View();
        }

        [OverloadSelector]
        public ActionResult Overload(string name)
        {
            this.ViewBag.Name = name;

            return this.View();
        }

        [OverloadSelector]
        public ActionResult Overload(string name, int age)
        {
            this.ViewBag.Name = name;
            this.ViewBag.Age = age;

            return this.View();
        }
    }
}