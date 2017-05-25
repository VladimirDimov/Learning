namespace CsvMediaTypeFormatterDemo.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using CsvMediaTypeFormatterDemo.Models;

    public class PeopleController : ApiController
    {
        private static List<Person> peopleRepository = new List<Person>();

        public IHttpActionResult Get()
        {
            return this.Ok(peopleRepository);
        }

        public IHttpActionResult Post(IEnumerable<Person> people)
        {
            peopleRepository.AddRange(people);

            return this.Ok(peopleRepository);
        }

        
    }
}