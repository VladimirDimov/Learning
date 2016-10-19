using System;
using System.Threading;
using System.Threading.Tasks;

public static class Program
{
    private static int value = 1;

    public static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            //if (value == 1)
            //{
            //    // Removing the following line will change the output
            //    Thread.Sleep(1000);
            //    value = 2;
            //}

            Thread.Sleep(1000);
            Interlocked.Exchange(ref value, 2);
        });

        Task t2 = Task.Run(() =>
        {
            value = 3;
        });

        Task.WaitAll(t1, t2);
        Console.WriteLine(value); // Displays 2
    }
}
