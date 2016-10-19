using System;
using System.Threading;
using System.Threading.Tasks;
namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                var childTasks = new Task[3];

                new Task(
                        () =>
                        {
                            Thread.Sleep(1000);
                            results[0] = 1;
                        }, TaskCreationOptions.AttachedToParent)
                        .Start();

                new Task(
                    () =>
                    {
                        Thread.Sleep(1000);
                        results[1] = 2;
                    }, TaskCreationOptions.AttachedToParent)
                    .Start();

                new Task(
                    () =>
                    {
                        Thread.Sleep(1000);
                        results[2] = 3;
                    }, TaskCreationOptions.AttachedToParent)
                    .Start();

                return results;
            });

            var finalTask = parent.ContinueWith(
                                                parentTask =>
                                                {
                                                    foreach (int i in parentTask.Result)
                                                    {
                                                        Console.WriteLine(i);
                                                    }
                                                });

            finalTask.Wait();
        }
    }
}