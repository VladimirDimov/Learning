namespace HttpParameterBindingDemo.ModelBinding
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
    using Models;

    public class BaseModelParamBinding : HttpParameterBinding
    {
        private HttpParameterBinding defaultFromBodyBinding;

        public BaseModelParamBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            // GetBinding() returns ModelBinderParameterBinding
            //defaultFromBodyBinding = new ModelBinderAttribute().GetBinding(descriptor);

            // GetBinding() returns FormatterParameterBinding
            defaultFromBodyBinding = new FromBodyAttribute().GetBinding(descriptor);
        }

        public override async Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            await defaultFromBodyBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);

            var model = actionContext.ActionArguments[Descriptor.ParameterName];

            var baseModel = model as BaseModel;
            baseModel.UserId = int.Parse(actionContext.Request.Headers.GetValues("UserId").First());
        }
    }
}