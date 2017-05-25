namespace ControllerSelectorDemo.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    public class BypassCacheSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;

        public BypassCacheSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
#if DEBUG
            // Uncomment to enable caching
            //return base.SelectController(request);
            var assemblies = _configuration.Services.GetAssembliesResolver().GetAssemblies();
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetTypes());
            }

            var matchedTypes = types.Where(i => typeof(IHttpController).IsAssignableFrom(i)).ToList();
            var controllerName = base.GetControllerName(request);
            var matchedController =
                matchedTypes.FirstOrDefault(i => i.Name.ToLower() == controllerName.ToLower() + "controller");

            return new HttpControllerDescriptor(_configuration, controllerName, matchedController);
#else
            return base.SelectController(request);
#endif
        }
    }
}