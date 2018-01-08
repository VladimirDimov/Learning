namespace WcfApp.ErrorHandling
{
    public class DefaultErrorHandlerAttribute : GlobalErrorBehaviorAttribute
    {
        public DefaultErrorHandlerAttribute()
            : base(typeof(GlobalErrorHandler))
        {
        }
    }
}