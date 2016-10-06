namespace ConcurrentDictionary
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new ConcurrentDictionary<int, string>();

            // Test writing
            Parallel.For(1, 1000000, (i) =>
            {
                dict.TryAdd(i, $"Item {i}");
            });

            // TestReading
            Parallel.ForEach(dict.Keys, (key) =>
            {
                var task1 = Task.Factory.StartNew(() =>
                {
                    var x = dict[key];
                });
                var task2 = Task.Factory.StartNew(() =>
                {
                    var x = dict[key];
                });
                var task3 = Task.Factory.StartNew(() =>
                {
                    var x = dict[key];
                });
            });
        }
    }
}
