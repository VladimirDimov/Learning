    public abstract class DelegatingHandler : HttpMessageHandler
    {
        protected DelegatingHandler();

        protected DelegatingHandler(HttpMessageHandler innerHandler);
        
        public HttpMessageHandler InnerHandler { get; set; }
        
        protected override void Dispose(bool disposing);
        
        protected internal override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken);
    }