namespace ActionFIltersDemo.Filters
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;

    public class AuthenticationFilter1 : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public string From { get; set; }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                //throw new ArgumentException();
                Trace.WriteLine($"{this.GetType().Name} is executing. {From}");
            });
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() => { });
        }
    }
}