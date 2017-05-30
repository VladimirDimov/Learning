using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ActionFIltersDemo
{
    internal class CustomMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //throw new ArgumentException();
            return base.SendAsync(request, cancellationToken);
        }
    }
}