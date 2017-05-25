namespace CustomActionResultDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public IHttpActionResult Get()
        {
            return this.NoContent();
        }
    }
}