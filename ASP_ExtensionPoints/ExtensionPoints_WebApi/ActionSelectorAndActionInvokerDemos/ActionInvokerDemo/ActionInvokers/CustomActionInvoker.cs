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
            return Task<HttpResponseMessage>.Run(async () =>
            {
                // No need to use try/catch. The default invoker does this
                var resultTask = base.InvokeActionAsync(actionContext, cancellationToken);

                if (resultTask.Exception != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(resultTask.Exception.Message),
                        ReasonPhrase = "Error"
                    };
                }

                var result = await resultTask;
                if (!result.IsSuccessStatusCode)
                {
                    var message = result;

                    switch (result.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            message.Content = result.Content;
                            message.ReasonPhrase = "Unauthorized";
                            var errorResult = new { Error = "The user is unauthorized" };
                            message.Content = new ObjectContent(errorResult.GetType(), errorResult, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
                            break;

                        default:
                            break;
                    }

                    return message;
                }

                return result;
            });
        }
    }
}
