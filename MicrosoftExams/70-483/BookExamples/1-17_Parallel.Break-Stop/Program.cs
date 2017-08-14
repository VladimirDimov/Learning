using System;
using System.Threading.Tasks;

namespace _1_17_Parallel.Break_Stop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ParallelLoopResult result =
                Parallel.For(0, 20, (int i, ParallelLoopState loopState) =>
                {
                    Console.WriteLine(i);
                    if (i == 10)
                    {
                        Console.WriteLine("Breaking loop");
                        loopState.Break();
                        //loopState.Stop();
                    }
                    return;
                });

            Console.WriteLine("========================================");
            Console.WriteLine(result.LowestBreakIteration);
            Console.Read();
        }
    }
}