using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class MyContext : DbContext
    {
        public MyContext() : base("DefaultConnection")
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer<MyContext>(null);
            
            modelBuilder
                .Entity<Person>()
                .Property(x => x.AddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder
                .Entity<Person>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder
                .Entity<Person>()
                .HasKey(x => x.Id, conf => conf.HasName("Id").IsClustered())
                .MapToStoredProcedures(proc => proc.Insert(config => config
                                                                            .HasName("Insert_Person")
                                                                            .Parameter(x => x.AddressId, "AddressId")));
        }
    }
}
