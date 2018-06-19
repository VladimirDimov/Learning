using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class MyContext1 : DbContext
    {
        public MyContext1() : base("Connection1")
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
