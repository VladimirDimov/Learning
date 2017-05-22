using System.Threading;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using CustomMessageHandlersDemo.ModelBinders;
using CustomMessageHandlersDemo.Models;

namespace CustomMessageHandlersDemo.Controllers
{
    public class DateController : ApiController
    {
        public IHttpActionResult Post(/*[ModelBinder(typeof(DateModelBinder))]*/ DatePostViewModel date)
        {
            return this.Ok(new
            {
                date = date,
                Culture = Thread.CurrentThread.CurrentCulture.Name,
                datePattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
            });
        }
    }
}