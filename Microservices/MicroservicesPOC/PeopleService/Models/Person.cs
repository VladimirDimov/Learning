using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleService.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }
    }
}