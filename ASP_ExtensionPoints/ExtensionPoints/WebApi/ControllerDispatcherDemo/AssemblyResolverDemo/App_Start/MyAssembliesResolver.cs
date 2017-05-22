namespace AssemblyResolverDemo
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Http.Dispatcher;

    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            var filePath = @"C:\Users\vdimov\Desktop\Common\Learning\ASP_ExtensionPoints\ExtensionPoints\webapi\ControllerDispatcherDemo\AssemblyResolverDemo\lib\AssemblyResolverDemo.OtherProject.dll";
            var controllersAssembly = Assembly.LoadFrom(filePath);
            baseAssemblies.Add(controllersAssembly);

            return baseAssemblies;
        }
    }
}