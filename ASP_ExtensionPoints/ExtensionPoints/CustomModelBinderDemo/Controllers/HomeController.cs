namespace CustomModelBinderDemo.Controllers
{
    using System.Web.Mvc;
    using ModelBinders;
    using ViewModels;

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

        public ActionResult ArrayDemo()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ArrayDemo([ModelBinder(typeof(PersonCollectionModelBinder))] Person[] people)
        {
            var isValid = this.ModelState.IsValid;
            return this.View();
        }
    }
}