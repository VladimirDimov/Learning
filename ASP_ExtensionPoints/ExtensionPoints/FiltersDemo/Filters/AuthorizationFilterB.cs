namespace FiltersDemo.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class AuthorizationFilterB : AuthorizeAttribute
    {
        public AuthorizationFilterB()
        {
            this.Order = 0;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Debug.WriteLine("AuthorizationFilterB");
        }
    }
}