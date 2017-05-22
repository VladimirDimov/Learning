using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace CustomMessageHandlersDemo.ModelBinders
{
    public class DateModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;

            return true;
        }
    }
}