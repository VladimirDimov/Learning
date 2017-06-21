namespace ActionFIltersDemo.Controllers
{
    using System;
    using System.Web.Http;
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
            throw new ArgumentException();
            return this.Ok("Home");
        }
    }
}