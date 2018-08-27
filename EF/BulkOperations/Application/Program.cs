using Application.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Application
{
    internal class Program
    {
        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, Configuration>());
            var context = new MyContext();
            context.Database.Initialize(true);


            //var sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine("Bulk insert started ...");
            //for (int i = 0; i < 1000; i++)
            //{
            //    context.People.Add(new Person
            //    {
            //        Name = Any.String(3, 10),
            //    });
            //}
            //context.SaveChanges();
            //sw.Stop();
            //Console.WriteLine($"Milliseconds: {sw.ElapsedMilliseconds}");


            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Bulk insert started ...");

            var dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Streer", typeof(string));
            dataTable.Columns.Add(new DataColumn("Number", typeof(int)) { AllowDBNull = true });
            for (int i = 0; i < 1000; i++)
            {
                dataTable.Rows.Add("bulk_" + Any.String(), null, null);
            }

            SqlParameter parameter = new SqlParameter("@People", dataTable) { TypeName = "dbo.PeopleList" };

            var res = context.Database.SqlQuery<string>("EXEC dbo.AddPeople @People", parameter);
            var list = res.ToList();
            //Console.WriteLine(list.Count);
            sw.Stop();

            Console.WriteLine($"Milliseconds: {sw.ElapsedMilliseconds}");
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public int? AddressId { get; set; }
    }

    public class Address
    {
        public Address()
        {
            this.People = new HashSet<Person>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public string Street { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}