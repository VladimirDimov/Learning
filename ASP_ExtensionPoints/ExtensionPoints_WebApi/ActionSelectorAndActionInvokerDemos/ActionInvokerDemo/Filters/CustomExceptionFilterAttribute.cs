namespace WebApi.CustomActionInvokerDemo.Filters
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;

    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            //throw new ArgumentException();

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}