namespace CustomControllerSelectorDemo.Controllers
{
    using System.Web.Http;

    // In this controller the overload is working!
    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string name)
        {
            return this.Ok(name);
        }

        public IHttpActionResult Get(string firstName, string lastName)
        {
            return this.Ok($"{firstName} {lastName}");
        }
    }
}