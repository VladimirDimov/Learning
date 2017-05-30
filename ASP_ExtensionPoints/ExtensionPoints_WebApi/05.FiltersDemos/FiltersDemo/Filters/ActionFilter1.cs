namespace ActionFIltersDemo.Filters
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class ActionFilter1 : Attribute, IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine($"{this.GetType().Name} is executing");

            var result = await continuation();

            Trace.WriteLine($"{this.GetType().Name} was executed");

            return result;
        }
    }
}