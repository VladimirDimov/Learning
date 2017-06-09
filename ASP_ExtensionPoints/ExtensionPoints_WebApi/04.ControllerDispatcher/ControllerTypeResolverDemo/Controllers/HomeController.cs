﻿namespace ControllerTypeResolverDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home Page");
        }
    }
}