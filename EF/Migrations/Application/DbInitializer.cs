using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class DbInitializer : CreateDatabaseIfNotExists<MyContext>
    {
        public override void InitializeDatabase(MyContext context)
        {
            base.InitializeDatabase(context);
            Seed(context);
        }

        protected override void Seed(MyContext context)
        {
            if (!context.People.Any())
            {
                context.People.Add(new Person { });
                context.SaveChanges();
            }
        }
    }
}
