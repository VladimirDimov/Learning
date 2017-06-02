namespace ModelValidationDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using Models;

    public class PeopleController : ApiController
    {
        public static List<PersonModel> people = new List<PersonModel>
        {
            new PersonModel {FirstName = "Dietrich", LastName = "Schechter", Age = 80 },
            new PersonModel {FirstName = "Ekkehard", LastName = "Saudek", Age = 20 },
            new PersonModel {FirstName = "Bernhard", LastName = "Schwanthaler", Age = 3 }
        };

        // GET: api/People
        public IHttpActionResult Get()
        {
            return this.Ok(people);
        }

        // POST: api/People
        public IHttpActionResult Post(PersonModel model)
        {
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest(ModelState);
            //}

            people.Add(model);

            return this.Ok();
        }
    }
}