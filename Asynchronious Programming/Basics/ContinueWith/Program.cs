namespace ContinueWith
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var firstTask = Task.Factory.StartNew<string>(() =>
            {
                Console.WriteLine("Enter some text:");
                var result = Console.ReadLine();
                return result;
            });

            var secondTask = firstTask.ContinueWith((ft) =>
            {
                Console.WriteLine($"You entered: {ft.Result}");
            });

            secondTask.Wait();
        }
    }
}
