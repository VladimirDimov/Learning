namespace CustomValueProviderDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.ValueProviders;
    using App_Start;
    using Models;

    public class HomeController : ApiController
    {
        // The value provider can be specified explicitly, but the api will use the first provider that is able to provide the parameter value, 
        // so in this case both [ValueProvider] and [ModelBinder] will work;
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