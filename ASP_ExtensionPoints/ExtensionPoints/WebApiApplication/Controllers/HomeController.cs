using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApiApplication.Controllers
{
    public class HomeController : ApiController
    {
        public ActionResult Index()
        {
            var test = this.RequestContext.RouteData.Values["test123"];

            return null;
        }
    }
}
