namespace TaskRun
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                var task = Task.Run(new Action(SayHello));
            }

            Console.ReadLine();
        }

        private static void SayHello()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello");
        }
    }
}
