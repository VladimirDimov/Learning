namespace MediaTypeFormattersDemo.App_Start
{
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class SetCultureHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string language = request.Headers.GetValues("lang").First();

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            return base.SendAsync(request, cancellationToken);
        }
    }
}