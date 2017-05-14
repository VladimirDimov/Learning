namespace CustomValueProviderDemo.ValueProviders
{
    using System.Web.Mvc;

    public class SessionValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new SessionValueProvider();
        }
    }
}