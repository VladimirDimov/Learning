namespace AngularWithWebApi.Controllers
{
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;

    public class HomeController : ApiController
    {
        static List<object> people =
                            new List<object>()
                            {
                                new { name= "Pesho"},
                                new { name= "Misho"},
                                new { name= "Gosho"},
                                new { name= "Tosho"},
                            };

        [HttpGet]
        public IHttpActionResult Index()
        {
            return this.Ok(people);
        }

        [HttpPost]
        public IHttpActionResult Post(AddPersonModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            people.Add(new { name = model.Name });

            return this.Ok();
        }
    }
}
