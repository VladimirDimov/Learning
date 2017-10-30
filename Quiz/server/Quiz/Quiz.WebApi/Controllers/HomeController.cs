namespace Quiz.WebApi.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize()]
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Json("Home Page");
        }
    }
}