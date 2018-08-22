using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(FormModel model)
        {
            model =new FormModel()
            {
                FormTypeId = 1
            };

            this.ModelState.Clear();

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitForm(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.PartialView("_Section1", model);
            }

            return this.PartialView("_Section2");
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