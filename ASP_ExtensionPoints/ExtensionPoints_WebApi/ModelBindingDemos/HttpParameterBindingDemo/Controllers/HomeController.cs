namespace HttpParameterBindingDemo.Controllers
{
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using Models;

    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Home GET");
        }

        public IHttpActionResult Post(CustomerOrder model)
        {
            return this.Ok(model);
        }
    }
}