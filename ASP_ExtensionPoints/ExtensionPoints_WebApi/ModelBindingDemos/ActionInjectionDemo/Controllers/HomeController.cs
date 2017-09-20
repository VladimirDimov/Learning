namespace ActionInjectionDemo.Controllers
{
    using System.Web.Http;
    using ParameterInjection;
    using Services;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string name, [Inject] IMyService service)
        {
            var result = new
            {
                Name = name,
                FromService = service.Get()
            };

            return this.Ok(result);
        }
    }
}