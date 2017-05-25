namespace CsvMediaTypeFormatterDemo.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using CsvMediaTypeFormatterDemo.Models;

    public class CarsController : ApiController
    {
        private static List<Car> carsRepository = new List<Car>();

        public IHttpActionResult Post(IEnumerable<Car> cars)
        {
            carsRepository.AddRange(cars);

            return this.Ok(carsRepository);
        }
    }
}