using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeInt
{
    class Program
    {
        private static object _locker = new object();
        static void Main()
        {
            var number = 0;
            var tasks = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);

                    for (int counter = 0; counter < 100000; counter++)
                    {
                        lock (_locker)
                        {
                            number++;
                        }
                    }

                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(number);
            Console.ReadLine();
        }
    }
}
