using System;

namespace _1_75_UsingDelegates
{
    internal class Program
    {
        public delegate int Calculate(int x, int y);

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        public static void Main()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4)); // Displays 7
            calc = Multiply;
            Console.WriteLine(calc(3, 4)); // Displays 12
        }
    }
}