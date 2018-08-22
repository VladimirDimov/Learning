using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Application.Migrations;

namespace Application
{
    internal class Program
    {
        private static void Main()
        {
            var configuration = new Configuration();
            var context = new MyContext();
            //configuration.ForceSeed(context);

            var people = context.People;
            var addresses = context.Addresses;

            var leftJoin = people.GroupJoin(addresses, p => p.AddressId, a => a.Id, (p, a) => new
            {
                PersonID = p.Id,
                Streets = a
            })
            .SelectMany(x => x.Streets.DefaultIfEmpty(), (x, a) => new
            {
                x.PersonID,
                a.Street
            }).ToList();

            var result = leftJoin.ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => $"{{PersonID: {x.PersonID}, Street: {x.Street ?? "NULL"}}}")));
        }
    }

    internal class Person
    {
        public int Id { get; set; }

        public int? AddressId { get; set; }
    }

    internal class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }
    }
}