using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var html = this.RenderView(this.ControllerContext, "PdfTemplate");
            var bytes = this.PdfBytes(html);
            var fileName = this.GeneratePdfFileName();
            return this.File(bytes, "application/pdf", fileName);
        }

        private string GeneratePdfFileName()
        {
            return $"app-form.pdf";
        }

        private byte[] PdfBytes(string html)
        {
            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(html)))
            {
                Document source = new Document(stream, new HtmlLoadOptions());
                using (var outputStream = new MemoryStream())
                {
                    source.Save(outputStream, SaveFormat.Pdf);
                    var bytes = outputStream.ToArray();

                    return bytes;
                }
            }
        }

        [HttpGet]
        public PartialViewResult RenderPdfTemplate()
        {
            return this.PartialView("PdfTemplate", "This is from print button.");
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

        private string RenderView(ControllerContext controllerContext, string viewName)
        {
            PartialViewResult result = new PartialViewResult();
            result.ViewData.Model = "dfokndsafondsafokdsanf";
            result.View = ViewEngines.Engines.FindPartialView(controllerContext, viewName).View;
            using (var sw = new StringWriter())
            {
                ViewContext vc = new ViewContext(controllerContext, result.View, result.ViewData, result.TempData, sw);
                result.View.Render(vc, sw);
                var html = sw.GetStringBuilder().ToString();

                return html;
            }
        }
    }
}