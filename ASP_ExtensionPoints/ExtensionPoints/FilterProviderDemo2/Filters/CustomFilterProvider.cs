using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterProviderDemo2.Filters
{
    public class CustomFilterProvider : FilterAttributeFilterProvider
    {
        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor.IsDefined(typeof(SkipGlobalActionFilters), false))
            {
                return new List<Filter>();
            }

            var filters = base.GetFilters(controllerContext, actionDescriptor);

            return filters;
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetActionAttributes(controllerContext, actionDescriptor);

            return filters;
        }

        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetControllerAttributes(controllerContext, actionDescriptor);

            return filters;
        }
    }
}