using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class MyContext2 : DbContext
    {
        public MyContext2() : base("Connection2")
        {
        }

        public DbSet<Address> Addresses { get; set; }
    }
}
