using System;
using System.Threading;
using System.Threading.Tasks;
namespace Chapter1.Threads
{
    public class Program
    {
        private static void F()
        {
            Console.WriteLine("F");
        }

        private static void G()
        {
            Console.WriteLine("G");
        }

        static void Main()
        {
            CancellationTokenSource cancellationTokenSource =
            new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            task.Wait();

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}