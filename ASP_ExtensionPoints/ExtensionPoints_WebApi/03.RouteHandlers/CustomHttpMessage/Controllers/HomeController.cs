﻿namespace WebApi.RouteHandlers.CustomHttpMessage.Controllers
{
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }
    }
}