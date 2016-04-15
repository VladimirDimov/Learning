using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeQueue
{
    class Program
    {
        static void Main()
        {
            var queue = new Queue<int>();
            var task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    queue.Enqueue(i);
                }
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            });

            var task3 = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            });

            Task.WaitAll(task1, task2, task3);
        }
    }
}
