namespace ActionFIltersDemo.Filters
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class AuthorizationFilter1 : AuthorizationFilterAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Trace.WriteLine($"{this.GetType().Name} is executing.");
            });
        }
    }
}