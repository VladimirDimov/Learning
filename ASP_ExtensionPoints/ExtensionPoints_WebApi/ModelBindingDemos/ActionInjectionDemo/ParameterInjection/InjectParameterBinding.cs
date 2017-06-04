namespace ActionInjectionDemo.ParameterInjection
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;

    public class InjectParameterBinding : HttpParameterBinding
    {
        public InjectParameterBinding(HttpParameterDescriptor descriptor) 
            : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.ControllerContext.Configuration.DependencyResolver != null)
            {
                var resolved = actionContext.Request.GetDependencyScope().GetService(this.Descriptor.ParameterType);
                actionContext.ActionArguments[this.Descriptor.ParameterName] = resolved;
            }

            return Task.FromResult(0);
        }
    }
}