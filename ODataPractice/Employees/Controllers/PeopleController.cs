using Employees.Models;
using Microsoft.OData;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace Employees.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Employees.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Person>("People");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class PeopleController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/People
        public IHttpActionResult GetPeople(ODataQueryOptions<Person> queryOptions)
        {
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IEnumerable<Person>>(Data.Data.Employees);
        }

        // GET: odata/People(5)
        [SecureAccess]
        public IHttpActionResult GetPerson([FromODataUri] int key, ODataQueryOptions<Person> queryOptions)
        {
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<Person>(Data.Data.Employees.First(x => x.PersonId == key));
        }

        // PUT: odata/People(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Person> delta)
        {
            Validate(delta.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = Data.Data.Employees.FirstOrDefault(x => x.PersonId == key);
            if (person == null)
            {
                return this.NotFound();
            }

            delta.Put(person);

            return this.Updated(person);
        }

        // POST: odata/People
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nextId = Data.Data.Employees.Max(x => x.PersonId) + 1;
            person.PersonId = nextId;
            Data.Data.AddEmployee(person);

            return Created(person);
        }

        // PATCH: odata/People(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Person> delta)
        {
            var person = Data.Data.Employees.FirstOrDefault(x => x.PersonId == key);
            var copyOfPerson = person.DeepCopy();
            if (person == null)
            {
                return this.NotFound();
            }

            delta.Patch(copyOfPerson);

            this.Validate(copyOfPerson);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            delta.Patch(person);

            return this.Updated(person);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var entity = Data.Data.Employees.FirstOrDefault(x => x.PersonId == key);
            if (entity == null)
            {
                return this.NotFound();
            }

            Data.Data.Remove(entity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult ModifySalary([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal newSalary = (decimal)parameters["Salary"];

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public IHttpActionResult GetMaxSalary()
        {
            return this.Ok(Data.Data.Employees.Max(e => e.Salary));
        }
    }
}