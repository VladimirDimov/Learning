using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var initializer = new MigrateDatabaseToLatestVersion<MyContext, Configuration>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            initializer.InitializeDatabase(context);

            var people = context.People;
            var addresses = context.Addresses;
        }
    }
}