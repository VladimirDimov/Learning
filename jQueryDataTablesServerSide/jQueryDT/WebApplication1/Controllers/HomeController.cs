using JQDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public static List<Person> peopleCollection = new List<Person>();

        public ActionResult Index(DataTableAjaxPostModel model)
        {
            return this.View();
        }

        [JQDataTable]
        public ActionResult GetData()
        {
            peopleCollection.Add(new Person { Age = 50, Id = 1001, Name = "asdfdsa", Town = ".[;,efkjmj" });

            return this.View(peopleCollection.AsQueryable().OrderBy(x => x.Age));
        }
    }
}