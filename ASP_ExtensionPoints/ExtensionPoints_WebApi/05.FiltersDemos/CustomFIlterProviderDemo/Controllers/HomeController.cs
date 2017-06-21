namespace CustomFIlterProviderDemo.Controllers
{
    using System.Web.Http;
    using CustomFIlterProviderDemo.Filters;

    [CustomControllerFilter]
    public class HomeController : ApiController
    {
        //[SkipControllerFilterAttributes]
        [CustomActionFilter1]
        [CustomActionFilter2]
        [PriorityFilter]
        public IHttpActionResult Get()
        {
            return this.Ok("OK!");
        }
    }
}