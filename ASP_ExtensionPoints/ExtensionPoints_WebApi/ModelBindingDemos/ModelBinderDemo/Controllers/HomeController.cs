namespace ModelBinderDemo.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using ModelBinderDemo.App_Start;
    using ModelBinderDemo.Models;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home");
        }

        [HttpPost]
        public IHttpActionResult Post([ModelBinder(typeof(AnimalsModelBinder))] IEnumerable<IAnimal> animals)
        {
            return this.Ok(animals.Select(x => x.Speak()));
        }
    }
}