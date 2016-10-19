using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulingDifferentContinuationTasks
{
    internal class Program
    {
        private static void Main()
        {
            var tokenSource = new CancellationTokenSource();

            Task t = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("42");
                        tokenSource.Token.ThrowIfCancellationRequested();
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Thread.CurrentThread.Join();
                    }
                }
            }, tokenSource.Token);

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Canceled");
            //}, TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadKey();
            tokenSource.Cancel();

            t.Wait();
        }
    }
}
