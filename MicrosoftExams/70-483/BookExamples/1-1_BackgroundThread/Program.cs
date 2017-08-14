using System;
using System.Threading;
namespace Chapter1
{
    public static class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
        public static void Main()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();
            //t.Join();     // If we set join it will work as background too!!!
            Console.WriteLine(Thread.CurrentThread.IsBackground);
        }
    }
}
