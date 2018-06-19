using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Migrations;

namespace Application
{
    class Program
    {
        static void Main()
        {
            var configuration = new Configuration();
            var context = new MyContext();
            //configuration.ForceSeed(context);

            var people = context.People;
            var addresses = context.Addresses;

            //var leftJoin = people.SelectMany(
            //                    x => addresses.Where(a => a.Id == x.AddressId).DefaultIfEmpty(),
            //                    (x, y) => new { PersonID = x.Id, Street = y != null ? y.Street : null});

            var leftJoin = people.GroupJoin(addresses, p => p.AddressId, a => a.Id, (p, a) => new
            {
                PersonID = p.Id,
                Streets = a
            })
            .SelectMany(x => x.Streets.DefaultIfEmpty(), (x, a) => new
            {
                x.PersonID,
                a.Street
            });

            var result = leftJoin.ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => $"{{PersonID: {x.PersonID}, Street: {x.Street ?? "NULL"}}}")));
        }
    }

    public static class Extensions
    {
        public static IQueryable<TResult> LeftOuterJoin<TPerson, TAddress, TKey, TResult>(
            this IQueryable<TPerson> outer,
            IEnumerable<TAddress> inner,
            Expression<Func<TPerson, TKey>> outerKeySelector,
            Expression<Func<TAddress, TKey>> innerKeySelector,
            Expression<Func<TPerson, TAddress, TResult>> resultSelector)
        {
            var leftJoin = outer.GroupJoin(inner, outerKeySelector, innerKeySelector, (p, a) => new
            {
                Key = p,
                Collection = a
            })
           .SelectMany(x => x.Collection.DefaultIfEmpty(), (a, b) => resultSelector.Compile().Invoke(a.Key, b));

            return leftJoin;
        }
    }

    class Person
    {
        public int Id { get; set; }

        public int? AddressId { get; set; }
    }

    class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }
    }
}
