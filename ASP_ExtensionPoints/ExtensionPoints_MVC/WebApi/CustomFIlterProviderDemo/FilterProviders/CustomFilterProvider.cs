namespace CustomFIlterProviderDemo.FilterProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Filters;

    public class CustomFilterProvider : ExtendableFilterProvider
    {
        public CustomFilterProvider(IFilterProvider extendFrom)
            : base(extendFrom)
        {
        }

        public override IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);

            filters = this.FilterFilters(filters);
            filters = this.SetPriorityFiltersOnTop(filters);

            return filters;
        }

        private IEnumerable<FilterInfo> FilterFilters(IEnumerable<FilterInfo> filters)
        {
            if (filters.Any(f => f.Instance.GetType() == typeof(SkipControllerFilterAttributes)))
            {
                filters = this.RemoveControllerFilters(filters);
            }

            return filters;
        }

        private IEnumerable<FilterInfo> RemoveControllerFilters(IEnumerable<FilterInfo> filters)
        {
            var filteredFilters = filters.Where(f => f.Instance.GetType() != typeof(SkipControllerFilterAttributes) && f.Scope != FilterScope.Controller);

            return filteredFilters;
        }

        private IEnumerable<FilterInfo> SetPriorityFiltersOnTop(IEnumerable<FilterInfo> filters)
        {
            var priorityFilters = new List<FilterInfo>();
            var nonPriorityFilters = new List<FilterInfo>();
            foreach (var filter in filters)
            {
                if (typeof(IPriorityFilter).IsAssignableFrom(filter.Instance.GetType()))
                {
                    var filterAsGlobal = new FilterInfo(filter.Instance, FilterScope.Global);
                    priorityFilters.Add(filterAsGlobal);
                }
                else
                {
                    nonPriorityFilters.Add(filter);
                }
            }

            return priorityFilters.Concat(nonPriorityFilters);
        }
    }
}