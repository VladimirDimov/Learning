using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application
{
    class Program
    {
        static void Main()
        {
            var context1 = new MyContext1();
            var context2 = new MyContext2();
            
            //context1.People.Add(new Person { Id = 0, AddressId = 0 });
            //context2.Addresses.Add(new Address { Id = 0, Street = "" });

            using (var transaction = new TransactionScope())
            {
                var person = context1.People.Add(new Person { Id = 1, AddressId = 123 });
                if (person != null)
                {
                    context2.Addresses.Add(new Address { Id = 123, Street = "Some street 123" });
                }

                context1.SaveChanges();
                context2.SaveChanges();

                transaction.Complete();
            }

            Console.WriteLine(context1.People.Count());
            Console.WriteLine(context2.Addresses.Count());
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
