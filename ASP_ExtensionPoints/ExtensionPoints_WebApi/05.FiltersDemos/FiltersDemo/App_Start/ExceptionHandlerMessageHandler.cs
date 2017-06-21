namespace ActionFIltersDemo
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ExceptionHandlerMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var resultTask = await  base.SendAsync(request, cancellationToken);

                return resultTask;
            }
            catch (System.Exception ex)
            {
                return await Task.Run(() =>
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