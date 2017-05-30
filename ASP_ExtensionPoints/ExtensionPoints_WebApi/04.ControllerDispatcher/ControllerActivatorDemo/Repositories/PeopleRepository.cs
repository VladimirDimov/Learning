using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private static IEnumerable<Person> people = new List<Person>()
        {
            new Person { Name = "István", Age = 15 },
            new Person { Name = "Gerhard", Age = 20 },
        };

        public IEnumerable<Person> GetAll
        {
            get
            {
                return people;
            }
        }
    }
}