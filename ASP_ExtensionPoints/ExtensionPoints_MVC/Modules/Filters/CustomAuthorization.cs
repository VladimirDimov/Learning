namespace Modules.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class CustomAuthorization : AuthorizeAttribute
    {
        public IAuthRepo AuthRepo { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("OnAuthorization");
        }
    }
}