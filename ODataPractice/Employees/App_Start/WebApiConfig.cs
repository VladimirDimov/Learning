namespace Employees
{
    using Employees.Models;
    using Employees.ODataConfiguration;
    using System.Web.Http;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var oDataEdmModel = ODataBuilderConfig.Configure("odata", "odata", typeof(Person).Assembly);
            config.MapODataServiceRoute("odata", "odata", oDataEdmModel);
        }
    }
}