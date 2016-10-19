using System;
using System.Collections.Generic;
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
                TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
                var tasks = new List<Task>();

                tasks.Add(taskFactory.StartNew(() => { Thread.Sleep(1000); results[0] = 0; }));
                tasks.Add(taskFactory.StartNew(() => { Thread.Sleep(1000); results[1] = 1; }));
                tasks.Add(taskFactory.StartNew(() => { Thread.Sleep(1000); results[2] = 2; }));

                Task.WaitAll(tasks.ToArray());

                return results;
            });

            var finalTask = parent.ContinueWith(
                                            parentTask =>
                                            {
                                                foreach (int i in parentTask.Result)
                                                    Console.WriteLine(i);
                                            });

            finalTask.Wait();
        }
    }
}