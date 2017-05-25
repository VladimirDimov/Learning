namespace CustomActionResultDemo.ActionResults
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class NoContentActionResult : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            });
        }
    }
}