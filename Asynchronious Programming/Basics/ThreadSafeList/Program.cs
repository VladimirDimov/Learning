using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeList
{
    class Program
    {
        private static object locker = new object();

        static void Main()
        {
            var list = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
            };

            Parallel.For(0, 16, new ParallelOptions { MaxDegreeOfParallelism = list.Count }, (i) =>
              {
                  var strUsed = list.FirstOrDefault(x => Monitor.TryEnter(x));
                  Thread.Sleep(new Random().Next(1, 3000));
                  Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is using {strUsed}");
                  Monitor.Exit(strUsed);
              });
        }
    }
}
