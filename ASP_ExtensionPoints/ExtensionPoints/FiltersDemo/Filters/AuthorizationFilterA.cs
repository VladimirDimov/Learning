namespace FiltersDemo.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class AuthorizationFilterA : AuthorizeAttribute
    {
        public AuthorizationFilterA()
        {
            this.Order = 0;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("AuthorizationFilterA");
        }
    }
}