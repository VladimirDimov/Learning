using Application.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class MyContext : DbContext
    {
        public MyContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasRequired(x => x.Address)
                .WithMany(a => a.People)
                .HasForeignKey(p => p.AddressId);
        }
    }
}
