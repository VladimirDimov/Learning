namespace WebApiTest.Controllers
{
    using System.Web.Http;
    using WebApiTest.Repositories;

    public class HomeController : ApiController
    {
        private IPeopleRepository people;

        public HomeController(IPeopleRepository people)
        {
            this.people = people;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.people.GetAll);
        }
    }
}