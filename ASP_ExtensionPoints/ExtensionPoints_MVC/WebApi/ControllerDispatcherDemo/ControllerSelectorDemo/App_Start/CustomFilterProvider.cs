namespace ControllerSelectorDemo.App_Start
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class CustomFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            return new List<FilterInfo>();
        }
    }
}