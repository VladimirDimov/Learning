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
            var people = context.People;
            var addresses = context.Addresses;

            people.Add(new Person { AddressId = 100 });

            context.SaveChanges();
        }
    }
}