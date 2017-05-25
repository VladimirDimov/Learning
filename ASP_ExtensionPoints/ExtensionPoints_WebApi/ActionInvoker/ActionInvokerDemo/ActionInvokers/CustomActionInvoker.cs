namespace WebApi.CustomActionInvokerDemo.ActionInvokers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class CustomActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);

            if (result.Exception != null)
            {
                if (result.Exception is HttpResponseException)
                {
                    return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(result.Exception.Message),
                        ReasonPhrase = "Error"
                    });
                }

                return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(result.Exception.Message),
                    ReasonPhrase = "Error"
                });
            }

            return result;
        }
    }
}
