namespace CustomControllerSelectorDemo.Controllers
{
    using System.Web.Http;

    public class PeopleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetById(string id)
        {
            return this.Ok("Get by id");
        }

        [HttpGet]
        public IHttpActionResult GetByName(string name)
        {
            return this.Ok("Get by name");
        }
    }
}