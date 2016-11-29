using Employees.Models;
using Microsoft.OData;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;

namespace Employees.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Employees.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Position>("Positions");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class PositionsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Positions
        //[EnableQuery(AllowedQueryOptions  = AllowedQueryOptions.All | AllowedQueryOptions.Select)]
        [EnableQuery]
        public IHttpActionResult GetPositions(ODataQueryOptions<Position> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<IEnumerable<Position>>(Data.Data.Positions);
        }

        // GET: odata/Positions(5)
        [EnableQuery]
        public IHttpActionResult GetPosition([FromODataUri] int key, ODataQueryOptions<Position> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok<Position>(Data.Data.Positions.First(x => x.PositionId == key));
        }

        // PUT: odata/Positions(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Position> delta)
        {
            Validate(delta.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(position);

            // TODO: Save the patched entity.

            // return Updated(position);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Positions
        public IHttpActionResult Post(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(position);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Positions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Position> delta)
        {
            Validate(delta.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(position);

            // TODO: Save the patched entity.

            // return Updated(position);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Positions(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}