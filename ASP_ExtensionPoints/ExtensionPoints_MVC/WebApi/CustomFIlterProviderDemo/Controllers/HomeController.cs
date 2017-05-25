namespace CustomFIlterProviderDemo.Controllers
{
    using System.Web.Http;
    using CustomFIlterProviderDemo.Filters;

    [CustomControllerFilter]
    public class HomeController : ApiController
    {
        [CustomActionFilter1]
        [CustomActionFilter2]
        [PriorityFilter]
        //[SkipControllerFilterAttributes]
        public IHttpActionResult Get()
        {
            return this.Ok("OK!");
        }
    }
}