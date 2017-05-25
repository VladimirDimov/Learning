namespace CustomControllerSelectorDemo.Controllers
{
    using System.Web.Http;

    public class PeopleController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            return this.Ok("Get by id");
        }

        [HttpPost]
        public IHttpActionResult Student(Student student)
        {
            return this.Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Teacher(Teacher teacher)
        {
            return this.Ok(teacher);
        }
    }
}