namespace Application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Application.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        public void ForceSeed(Application.MyContext context)
        {
            this.Seed(context);
        }

        protected override void Seed(Application.MyContext context)
        {
            if (!context.People.Any())
            {
                context.People.Add(new Person { Id = 1, AddressId = 1 });
                context.People.Add(new Person { Id = 2, AddressId = 2 });
                context.People.Add(new Person { Id = 3, AddressId = 3 });

                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                context.Addresses.Add(new Address { Id = 1, Street = "Street 1" });
                context.Addresses.Add(new Address { Id = 3, Street = "Street 3" });
                context.SaveChanges();
            }
        }
    }
}
