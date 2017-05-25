namespace HttpServerDemo.ConsoleApp
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using HttpServerDemo.Api;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = WebApiApplication.GetHttpConfiguration();
            var server = new HttpServer(config);

            HttpMessageInvoker client = new HttpMessageInvoker(server);

            var result = client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/home"), new CancellationToken(false)).Result;

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }
    }
}