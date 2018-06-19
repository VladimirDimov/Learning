namespace Application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Application.MyContext1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        public void ForceSeed(Application.MyContext1 context)
        {
            this.Seed(context);
        }

        protected override void Seed(Application.MyContext1 context)
        {
        }
    }
}
