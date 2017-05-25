namespace FilterProviderDemo2
{
    using System.Web.Mvc;
    using FilterProviderDemo2.Filters;

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