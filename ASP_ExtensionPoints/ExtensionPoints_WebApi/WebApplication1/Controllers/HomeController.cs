namespace WebApplication1.Controllers
{
    using System;
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get(IMyService service)
        {
            throw new ArgumentException("Test exception");
            return this.Ok(service.Do());
        }
    }
}