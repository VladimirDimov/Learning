using System;

namespace _1_76_MulticastDelegate
{
    internal class Program
    {
        private static void Main()
        {
            Multicast();
        }

        public static void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }

        public static void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

        public delegate void Del();

        public static void Multicast()
        {
            Del d = MethodOne;
            d += MethodTwo;
            d();
        }

        // Displays
        // MethodOne
        // MethodTwo
    }
}