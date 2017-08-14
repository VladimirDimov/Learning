namespace CustomActionSelectorDemo.Controllers
{
    using System.Web.Http;

    public class HomeController : ApiController
    {
        [Gone]
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }
    }
}