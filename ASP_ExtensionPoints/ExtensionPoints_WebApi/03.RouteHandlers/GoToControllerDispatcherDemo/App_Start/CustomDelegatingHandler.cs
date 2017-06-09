namespace GoToControllerDispatcherDemo
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    internal class CustomDelegatingHandler : DelegatingHandler
    {
        public CustomDelegatingHandler(HttpConfiguration config)
        {
            // This configures the handler to call the controller dispatcher.
            this.InnerHandler = new HttpControllerDispatcher(config);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("MyCustomHeader", "SomeCustomHeaderValue");

            return base.SendAsync(request, cancellationToken);
        }
    }
}