namespace CustomActionResultDemo.Controllers
{
    using System.Web.Http;
    using CustomActionResultDemo.ActionResults;

    public class BaseController : ApiController
    {
        public IHttpActionResult NoContent()
        {
            return new NoContentActionResult();
        }
    }
}