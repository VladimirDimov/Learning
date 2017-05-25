using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.SelfHost;

namespace AssemblyResolverDemo.Selfhost
{
    public partial class Service1 
    {
        private HttpSelfHostServer _server;
        private readonly HttpSelfHostConfiguration _config;
        public const string ServiceAddress = "http://localhost:8080";

        public Service1()
        {
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }

        }

        protected override void OnStart(string[] args)
        {
            _server = new HttpSelfHostServer(_config);
            _server.OpenAsync();
        }




        protected override void OnStop()
        {
            _server.CloseAsync().Wait();
            _server.Dispose();
        }
    }

}