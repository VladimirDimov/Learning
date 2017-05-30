namespace WebApplication1.Controllers
{
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get(IMyService service)
        {
            return this.Ok(service.Do());
        }
    }
}