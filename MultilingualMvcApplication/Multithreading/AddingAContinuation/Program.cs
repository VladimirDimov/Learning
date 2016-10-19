using System;
using System.Threading.Tasks;

namespace AddingAContinuation
{
    internal class Program
    {
        private static void Main()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            Console.WriteLine(t.Result); // Displays 84
        }
    }
}
