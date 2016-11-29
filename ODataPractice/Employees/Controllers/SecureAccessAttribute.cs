namespace Employees.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.OData;
    using System.Web.OData.Query;

    public class SecureAccessAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {            
            base.ValidateQuery(request, queryOptions);
        }
    }
}