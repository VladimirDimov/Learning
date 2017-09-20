namespace HttpServerDemo.Api.Controllers
{
    using System.Configuration;
    using System.Web.Http;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            var test1 = ConfigurationManager.AppSettings["test1"];

            return this.Ok($"Home Page; Test1 = {test1}");
        }
    }
}