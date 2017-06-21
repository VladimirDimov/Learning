namespace AssemblyResolverDemo
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Web.Http.Dispatcher;

    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            var folder = @"C:\Users\vdimov\Desktop\00.Common\Learning\ASP_ExtensionPoints\ExtensionPoints_WebApi\04.ControllerDispatcher\AssemblyResolver\AssemblyResolverDemo\lib";
            var directoryInfo = new DirectoryInfo(folder);
            var files = directoryInfo.GetFileSystemInfos("*.dll");
            foreach (var file in files)
            {
                var controllersAssembly = Assembly.LoadFrom(file.FullName);
                baseAssemblies.Add(controllersAssembly);
            }

            return baseAssemblies;
        }
    }
}