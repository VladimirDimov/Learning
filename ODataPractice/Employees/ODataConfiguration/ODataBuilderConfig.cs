namespace Employees.ODataConfiguration
{
    using Models;
    using ODataConfiguration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Filters;
    using System.Web.OData.Builder;
    using Microsoft.OData.Edm;

    public class ODataBuilderConfig
    {
        public static IEdmModel Configure(string name, string prefix, Assembly assembly)
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();

            var entitySets = GetODataEntitySets(assembly);
            SetODataEntitySets(entitySets, modelBuilder);

            var complexTypes = GetODataComplexTypes(assembly);
            SetODataComplexTypes(complexTypes, modelBuilder);

            return modelBuilder.GetEdmModel();
        }

        private static void SetODataComplexTypes(IEnumerable<Type> complexTypes, ODataConventionModelBuilder modelBuilder)
        {
            foreach (var type in complexTypes)
            {
                modelBuilder.AddComplexType(type);
            }
        }

        private static IEnumerable<Type> GetODataComplexTypes(Assembly assembly)
        {
            var complexTypes =
                            assembly
                            .GetExportedTypes() // Only public classes
                            .Where(
                                    x => Attribute.GetCustomAttribute(x, typeof(ODataComplexTypeAttribute)) != null
                                    && !x.IsInterface
                                    && !x.IsAbstract);

            return complexTypes;
        }

        private static void SetODataEntitySets(IEnumerable<Type> modelTypes, ODataConventionModelBuilder modelBuilder)
        {
            foreach (var type in modelTypes)
            {
                var entitySetMethodInfo = modelBuilder
                    .GetType()
                    .GetMethod(nameof(ODataConventionModelBuilder.EntitySet))
                    .MakeGenericMethod(type);

                var oDataModelAttribute = (ODataEntitySetAttribute)type
                    .GetCustomAttribute(typeof(ODataEntitySetAttribute));

                entitySetMethodInfo
                    .Invoke(modelBuilder, new string[] { oDataModelAttribute.ServiceRoute });

                // Run custom configuration method (if available)
                if (typeof(IHaveCustomODataConfiguration).IsAssignableFrom(type))
                {
                    var oDataEntitySetObj = Activator.CreateInstance(type);

                    type
                        .GetMethod(nameof(Person.CustomODataConfiguration))
                        .Invoke(oDataEntitySetObj, new object[] { modelBuilder });
                }
            }
        }

        private static IEnumerable<Type> GetODataEntitySets(Assembly assembly)
        {
            var entityTypes =
                            assembly
                            .GetExportedTypes() // Only public classes
                            .Where(
                                    x => Attribute.GetCustomAttribute(x, typeof(ODataEntitySetAttribute)) != null
                                    && !x.IsInterface
                                    && !x.IsAbstract);

            return entityTypes;
        }
    }

    public class ODataEntitySetAttribute : ActionFilterAttribute
    {
        public ODataEntitySetAttribute(string serviceRoute)
        {
            this.ServiceRoute = serviceRoute;
        }

        public string ServiceRoute { get; private set; }
    }

    public class ODataComplexTypeAttribute : ActionFilterAttribute { }
}