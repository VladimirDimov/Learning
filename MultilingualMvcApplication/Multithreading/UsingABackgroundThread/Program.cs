namespace Chapter1
{
    using System;
    using System.Threading;

    public static class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(300);
            }
        }

        public static void Main()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            t.IsBackground = true;
            //t.IsBackground = false;

            t.Start();
        }
    }
}
