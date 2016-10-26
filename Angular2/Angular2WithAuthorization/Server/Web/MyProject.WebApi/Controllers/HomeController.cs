namespace MyProject.WebApi.Controllers
{
    using System.Web.Http;

    [Authorize]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/home/test")]
        public IHttpActionResult Test()
        {
            return this.Ok("Success");
        }
    }
}
