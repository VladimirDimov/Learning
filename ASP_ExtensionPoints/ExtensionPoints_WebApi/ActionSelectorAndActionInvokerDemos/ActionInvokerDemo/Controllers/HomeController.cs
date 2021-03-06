﻿namespace WebApi.CustomActionInvokerDemo.Controllers
{
    using System;
    using System.Web.Http;
    using Filters;

    [CustomExceptionFilterAttribute]
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            throw new ArgumentException("This is a test exception");
            throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            //return this.Ok("OK!");
        }
    }
}