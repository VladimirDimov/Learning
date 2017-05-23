using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CustomActionResultDemo.ActionResults;

namespace CustomActionResultDemo.Controllers
{
    public class BaseController : ApiController
    {
        public IHttpActionResult NoContent()
        {
            return new NoContentActionResult();
        }
    }
}