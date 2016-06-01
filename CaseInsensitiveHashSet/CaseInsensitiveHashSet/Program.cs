using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseInsensitiveHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            hashSet.Add("pesho");
            hashSet.Add("Pesho");
            hashSet.Add("peSho");
            hashSet.Add("peshO");

            Console.WriteLine(hashSet.Contains("PESHO")); // index = true;
            Console.WriteLine(hashSet.Count); // returns 1
        }
    }
}
