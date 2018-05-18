using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Pdf;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPdf()
        {
            using (var sw = new StringWriter())
            {
                PartialViewResult result = RenderPdfTemplate();
                result.ViewData.Model = "dfokndsafondsafokdsanf";
                result.View = ViewEngines.Engines.FindPartialView(ControllerContext, "PdfTemplate").View;

                ViewContext vc = new ViewContext(ControllerContext, result.View, result.ViewData, result.TempData, sw);

                result.View.Render(vc, sw);

                var html = sw.GetStringBuilder().ToString();

                return this.Json(html, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult RenderPdfTemplate()
        {
            return this.PartialView("PdfTemplate");
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