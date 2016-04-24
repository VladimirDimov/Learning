using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoringTempData.Controllers
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var people = new Person[]
            {
                new Person {Name="Name 1", Age=20 },
                new Person {Name="Name 2", Age=20 },
                new Person {Name="Name 3", Age=20 },
                new Person {Name="Name 4", Age=20 },
                new Person {Name="Name 5", Age=20 },
                new Person {Name="Name 6", Age=20 },
            };

            this.TempData["People"] = people;

            return View();
        }

        public ActionResult SavePeople()
        {
            var people = this.TempData["People"];

            return new HttpStatusCodeResult(200);
        }
    }
}