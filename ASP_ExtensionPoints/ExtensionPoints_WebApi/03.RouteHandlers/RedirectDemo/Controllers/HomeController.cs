namespace RedirectDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }
    }
}