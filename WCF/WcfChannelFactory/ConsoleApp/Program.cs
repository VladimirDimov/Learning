namespace ConsoleApp
{
    using System;
    using Contracts;

    internal class Program
    {
        private static void Main()
        {
            var factory = new System.ServiceModel.ChannelFactory<IService1>("*");
            var channel = factory.CreateChannel();
            var type = channel.GetType();
            var response = channel.GetData(123);

            Console.WriteLine(response);
        }
    }
}