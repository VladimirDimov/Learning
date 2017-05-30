namespace CustomValueProviderDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.ValueProviders;
    using App_Start;
    using Models;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get([ValueProvider(typeof(CookieValueProviderFactory))] GeoPoint model, [ModelBinder] string test)
        {
            return this.Ok(new
            {
                Model = model,
                Test = test
            });
        }
    }
}