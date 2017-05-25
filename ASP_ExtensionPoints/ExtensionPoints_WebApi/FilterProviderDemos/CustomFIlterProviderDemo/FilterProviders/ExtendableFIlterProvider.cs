namespace CustomFIlterProviderDemo.FilterProviders
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class ExtendableFilterProvider : IFilterProvider
    {
        private IFilterProvider provider;

        public ExtendableFilterProvider(IFilterProvider extendFrom)
        {
            this.provider = extendFrom;
        }

        public virtual IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            return this.provider.GetFilters(configuration, actionDescriptor);
        }
    }
}