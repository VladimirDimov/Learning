namespace ActionFIltersDemo
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ExceptionHandlerMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return base.SendAsync(request, cancellationToken);
            }
            catch (System.Exception ex)
            {
                return Task.Run(() =>
                 {
                     var result = new { Message = ex.Message };
                     return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                     {
                         Content = new ObjectContent(result.GetType(), result, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
                     };
                 });
            }
        }
    }
}