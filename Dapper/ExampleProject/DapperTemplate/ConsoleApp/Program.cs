namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DapperTemplate.Data;

    class Program
    {
        static void Main()
        {
            var context = new DbContext();
            var res = context.Get();
        }
    }
}
