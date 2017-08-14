using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_22_AsParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();
        }
    }
}
