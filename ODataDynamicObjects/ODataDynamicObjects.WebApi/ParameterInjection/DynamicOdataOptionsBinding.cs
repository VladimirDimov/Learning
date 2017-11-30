namespace ODataDynamicObjects.WebApi.ParameterInjection
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Metadata;
    using System.Web.OData;
    using System.Web.OData.Builder;
    using System.Web.OData.Query;
    using System.Web.OData.Routing;
    using Microsoft.OData.Edm;
    using ODataDynamicObjects.WebApi.Models;

    public class DynamicOdataOptionsBinding : HttpParameterBinding
    {
        public DynamicOdataOptionsBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (actionContext.ControllerContext.Configuration.DependencyResolver != null)
                {
                    var edmModel = this.BuildEdmModel(typeof(PersonModel));
                    var queryOptions = new ODataQueryOptions(new ODataQueryContext(edmModel, typeof(PersonModel), new ODataPath()), actionContext.Request);
                    actionContext.ActionArguments[this.Descriptor.ParameterName] = queryOptions;
                }
            });
        }

        /// <summary>
        /// Builds EdmModel for a provided type.
        /// </summary>
        /// <param name="entryDtoDynamicType">The type argument.</param>
        /// <returns>Returns the EdmModel.</returns>
        private IEdmModel BuildEdmModel(Type entryDtoDynamicType)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            var entityType = builder.AddEntityType(entryDtoDynamicType);

            return builder.GetEdmModel();
        }
    }
}