namespace HttpServerDemo.ConsoleApp
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using HttpServerDemo.Api;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = WebApiApplication.GetHttpConfiguration();

            //// First approach with HttpMessageInvoker
            //var server = new HttpServer(config);
            //HttpMessageInvoker client = new HttpMessageInvoker(server);
            //var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/home");
            //var result = client.SendAsync(requestMessage, new CancellationToken(false)).Result;
            //Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            // Second custom approach
            var extendedServer = new TestHttpServer(config);
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/home");
            var result = extendedServer.Send(requestMessage);
            Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            Console.ReadLine();
        }
    }

    // This is a wrapper arround HttpServer. It is needed because the SendAsync method is protected and has to be exposed.
    public class TestHttpServer : HttpServer
    {
        public TestHttpServer(HttpConfiguration config)
            : base(config)
        {
        }

        public HttpResponseMessage Send(HttpRequestMessage request)
        {
            return this.SendAsync(request, new CancellationToken(false)).Result;
        }

        public new Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}