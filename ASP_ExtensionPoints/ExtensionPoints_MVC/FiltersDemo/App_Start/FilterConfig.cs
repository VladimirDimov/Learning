using System.Web;
using System.Web.Mvc;
using FiltersDemo.Filters;

namespace FiltersDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalFilter1());
            filters.Add(new GlobalFilter2());
        }
    }
}
