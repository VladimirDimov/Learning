namespace HttpServerDemo.Api.Controllers
{
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("This is GET from HOME");
        }
    }
}