namespace MvcRequestEntryPoints.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class CustomControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            requestContext.HttpContext.Request.Cookies.Add(new HttpCookie("name", "John Doe"));

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
