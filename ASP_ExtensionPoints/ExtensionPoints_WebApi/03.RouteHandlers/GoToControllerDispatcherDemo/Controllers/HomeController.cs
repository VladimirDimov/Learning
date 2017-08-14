namespace GoToControllerDispatcherDemo.Controllers
{
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            var requestHeaders = this.Request.Headers;
            return this.Ok("Home Page");
        }
    }
}