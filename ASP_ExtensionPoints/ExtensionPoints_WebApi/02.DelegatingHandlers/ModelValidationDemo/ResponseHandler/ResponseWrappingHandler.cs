using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModelValidationDemo.ResponseHandler
{
    public class ResponseWrappingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var incomingResult = await base.SendAsync(request, cancellationToken);

            var wrapedResult = new HttpResponseMessage();
            this.SetHeaders(incomingResult, wrapedResult);

            object content;
            var responsePackage = new ResponsePackage();
            if (incomingResult.TryGetContentValue(out content) && !incomingResult.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;
                var errorsCollection = new List<string>();
                if (error != null)
                {
                    this.ExtractErrorMessages(error, ref errorsCollection);
                }

                responsePackage.Errors = errorsCollection;
            }
            else
            {
                responsePackage.Result = ((System.Net.Http.ObjectContent)incomingResult.Content)?.Value;
            }

            wrapedResult.Content = new ObjectContent(typeof(ResponsePackage), responsePackage, GlobalConfiguration.Configuration.Formatters.JsonFormatter);

            return wrapedResult;
        }

        private void ExtractErrorMessages(HttpError error, ref List<string> errorsCollection)
        {
            if (error.InnerException != null)
            {
                this.ExtractErrorMessages(error, ref errorsCollection);
            }

            foreach (var value in error.Values)
            {
                var valueType = value.GetType();
                if (valueType == typeof(string))
                {
                    errorsCollection.Add(value as string);
                }
                else if (valueType == typeof(HttpError))
                {
                    this.ExtractErrorMessages(value as HttpError, ref errorsCollection);
                }
                else if (valueType == typeof(string[]))
                {
                    var valueAsStringArray = value as string[];
                    foreach (var message in valueAsStringArray)
                    {
                        errorsCollection.Add(message);
                    }
                }
            }
        }

        private void SetHeaders(HttpResponseMessage incomingResponse, HttpResponseMessage outcomingResponse)
        {
            foreach (var header in incomingResponse.Headers)
            {
                outcomingResponse.Headers.Add(header.Key, header.Value);
            }
        }
    }
}