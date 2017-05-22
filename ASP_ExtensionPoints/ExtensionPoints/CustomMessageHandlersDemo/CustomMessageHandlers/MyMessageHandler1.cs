namespace CustomMessageHandlersDemo.CustomMessageHandlers
{
    using System.Globalization;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyMessageHandler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Get the {language} parameter in the RouteData
            var routeData = request.GetRouteData();
            string language = routeData.Values["language"] as string;

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            return base.SendAsync(request, cancellationToken);
        }
    }
}