namespace WebApi.CustomActionInvokerDemo.Controllers
{
    using System;
    using System.Net.Http;
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            //return this.Ok("OK!");
        }

        public IHttpActionResult Post()
        {
            throw new ArgumentException();

            //return this.Ok("Post!");
        }
    }
}