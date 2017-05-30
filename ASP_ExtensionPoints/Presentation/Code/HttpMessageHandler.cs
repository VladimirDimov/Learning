    public abstract class HttpMessageHandler : IDisposable
    {
        protected HttpMessageHandler();

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        protected internal abstract Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken);
    }