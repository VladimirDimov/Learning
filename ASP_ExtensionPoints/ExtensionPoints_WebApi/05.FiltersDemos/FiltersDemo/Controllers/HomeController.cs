namespace ActionFIltersDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Filters;
    using Filters;

    [ActionFilter2]
    [AuthorizationFilter1]
    [AuthenticationFilter1(From = "From Controller")]
    public class HomeController : ApiController
    {
        [ActionFilter1]
        [AuthenticationFilter1(From = "From Action")]
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }
    }
}