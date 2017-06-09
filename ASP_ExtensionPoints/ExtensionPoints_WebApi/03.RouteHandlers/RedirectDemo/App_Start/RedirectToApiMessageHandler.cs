namespace RedirectDemo
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    internal class RedirectToApiMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
            //var redirectLocation = new Uri(request.RequestUri.Scheme + "://" + request.RequestUri.Authority + request.RequestUri.AbsolutePath.Substring(4));
            //var redirectResult = new RedirectResult(redirectLocation, request);

            //return redirectResult.ExecuteAsync(cancellationToken);
        }
    }
}