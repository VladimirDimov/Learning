namespace CustomValueProviderDemo.App_Start
{
    using System.Web.Http.Controllers;
    using System.Web.Http.ValueProviders;

    public class CookieValueProviderFactory : System.Web.Http.ValueProviders.ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return new CookieValueProvider(actionContext);
        }
    }
}