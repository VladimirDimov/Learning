namespace FilterProviderDemo.Filters
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using ConfigSections;

    public class CustomFilterProvider : FilterAttributeFilterProvider
    {
        private static HashSet<string> disabledFilters;

        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetControllerAttributes(controllerContext, actionDescriptor)
                .Where(f => !GetDisabledFilters().Any(df => df == f.GetType().FullName));

            return filters;
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetActionAttributes(controllerContext, actionDescriptor)
                .Where(f => !GetDisabledFilters().Any(df => df == f.GetType().FullName));

            return filters;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor)
                .Where(f => !GetDisabledFilters().Any(df => df == f.GetType().FullName));

            return filters;
        }

        private HashSet<string> GetDisabledFilters()
        {
            if (disabledFilters == null)
            {
                disabledFilters = new HashSet<string>();
                var filtersSettingsConfig = (FiltersSettings)ConfigurationManager.GetSection("FiltersSettings");

                foreach (FilterElement item in filtersSettingsConfig.FilterElement)
                {
                    if (!item.isactive)
                    {
                        disabledFilters.Add(item.type);
                    }
                }
            }

            return disabledFilters;
        }
    }
}