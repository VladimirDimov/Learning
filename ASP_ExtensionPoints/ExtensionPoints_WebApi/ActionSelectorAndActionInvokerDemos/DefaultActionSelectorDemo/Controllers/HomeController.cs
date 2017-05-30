namespace CustomControllerSelectorDemo.Controllers
{
    using System.Web.Http;

    // In this controller the overload is working!
    public class HomeController : ApiController
    {
        public IHttpActionResult DoSomething()
        {
            return this.Ok("Do something");
        }

        public IHttpActionResult DoSomethingElse()
        {
            return this.Ok("Do something else");
        }
    }
}