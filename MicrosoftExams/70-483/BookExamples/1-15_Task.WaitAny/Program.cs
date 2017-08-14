using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class Program
    {
        public static void Main()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(1000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(500); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(1500); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine($"Index: {i}; Result: {completedTask.Result};");
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }

        // Output:
        //
        // Index: 1; Result: 2;
        // Index: 0; Result: 1;
        // Index: 0; Result: 3;
    }
}