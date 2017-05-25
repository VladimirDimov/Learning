namespace MediaTypeFormattersDemo.Controllers
{
    using System.Web.Http;
    using Models;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }

        public IHttpActionResult Post(Person model)
        {
            return this.Ok(new
            {
                Person = model,
                Modelstate = this.ModelState
            });
        }
    }
}