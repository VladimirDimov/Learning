using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CustomControllerSelectorDemo.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string name)
        {
            return this.Ok(name);
        }

        public IHttpActionResult Get(string firstName, string lastName)
        {
            return this.Ok($"{firstName} {lastName}");
        }
    }
}
