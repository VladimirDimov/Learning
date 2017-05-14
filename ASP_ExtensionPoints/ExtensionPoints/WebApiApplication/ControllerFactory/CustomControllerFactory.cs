using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApiApplication.ControllerFactory
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            requestContext.RouteData.Values.Add("test123", "test123");
            return base.CreateController(requestContext, controllerName);
        }
    }
}