using System;
using System.Threading;
namespace Chapter1
{
    public static class Program
    {
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() =>
                                                 {
                                                    // Here the current thread is the corresponding thread that calls the _field. 
                                                    return Thread.CurrentThread.ManagedThreadId;
                                                 });

        public static void Main()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }

            }).Start();

            Console.ReadKey();
        }
    }
}
// Displays
// Thread B: 0
// Thread B: 1
// Thread B: 2
// Thread B: 3
// Thread A: 0
// Thread A: 1
// Thread A: 2