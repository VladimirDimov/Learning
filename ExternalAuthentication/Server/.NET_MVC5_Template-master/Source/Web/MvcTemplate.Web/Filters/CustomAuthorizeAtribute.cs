namespace MvcTemplate.Web.Filters
{
    using Services.Data;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;

    public class CustomAuthorizeAtribute : AuthorizeAttribute
    {
        public IUsersService UsersService { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var token = httpContext.Request.Headers["Token"];
            var user = this.UsersService.GetByToken(token);

            if (user == null)
            {
                return false;
            }

            httpContext
                .GetOwinContext()
                .Request.User = new GenericPrincipal(new GenericIdentity(user.UserName, httpContext.User.Identity.AuthenticationType), null);

            return base.AuthorizeCore(httpContext);
        }
    }
}