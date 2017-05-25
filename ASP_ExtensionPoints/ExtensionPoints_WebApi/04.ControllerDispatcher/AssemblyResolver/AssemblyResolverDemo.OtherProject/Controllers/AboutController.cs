namespace AssemblyResolverDemo.OtherProject.Controllers
{
    using System.Web.Http;

    public class AboutController : BaseController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("About Info");
        }
    }
}