using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactory
{
    class Program
    {
        static void Main()
        {
            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello world");
            });

            Console.WriteLine("Waiting ...");
            task.Wait();
            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
