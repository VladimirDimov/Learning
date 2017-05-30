namespace ActionInjectionDemo.Controllers
{
    using System.Web.Http;
    using ParameterInjection;
    using Services;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string name, [Inject] IMyService service)
        {
            return this.Ok(new
            {
                Name = name,
                FromService = service.Get()
            });
        }
    }
}