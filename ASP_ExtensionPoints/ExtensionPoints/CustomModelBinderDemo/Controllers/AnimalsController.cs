using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomModelBinderDemo.ModelBinders;
using CustomModelBinderDemo.ViewModels;

namespace CustomModelBinderDemo.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(AnimalsModelBinder))] IEnumerable<IAnimal> animals)
        {
            return this.View(nameof(this.List), animals);
        }

        public ActionResult List(IEnumerable<IAnimal> animals)
        {
            return this.View(animals);
        }
    }
}