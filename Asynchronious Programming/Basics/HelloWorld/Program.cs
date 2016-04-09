using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            var task = new Task(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Hello world");
            });
            task.Start();
            Console.WriteLine("Waiting");
            task.Wait();

            Console.ReadLine();
        }
    }
}
