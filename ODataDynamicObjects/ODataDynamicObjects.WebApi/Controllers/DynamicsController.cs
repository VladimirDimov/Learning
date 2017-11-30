namespace ODataDynamicObjects.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Query;
    using ODataDynamicObjects.WebApi.Models;
    using ODataDynamicObjects.WebApi.ParameterInjection;

    public class DynamicModelController : ODataController
    {
        private IEnumerable<BaseModel> data = new List<BaseModel>
        {
            new PersonModel{Id = 1, Name = "Gosho"},
            new PersonModel{Id = 2, Name = "Misho"},
        };

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Get([Inject]ODataQueryOptions options)
        {
            return this.Ok(data);
        }
    }
}