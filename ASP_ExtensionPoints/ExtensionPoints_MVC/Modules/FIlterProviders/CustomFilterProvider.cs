namespace Modules.FIlterProviders
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CustomFilterProvider : FilterAttributeFilterProvider
    {
        // http://odetocode.com/blogs/scott/archive/2011/01/19/configurable-action-filter-provider.aspx
        // Interesting case is when put settings in .config to switch filters on and off.

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            return base.GetFilters(controllerContext, actionDescriptor);
        }
    }
}