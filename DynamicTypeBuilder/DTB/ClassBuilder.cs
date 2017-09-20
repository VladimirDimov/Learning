namespace DTB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using System.Threading.Tasks;

    public class ClassBuilder
    {
        private ModuleBuilder moduleBuilder;
        private TypeBuilder typeBuilder;

        public ClassBuilder(string typeName, AppDomain myDomain, string assemblyName)
        {
            AssemblyName assemblyNameObject = new AssemblyName();
            assemblyNameObject.Name = assemblyName;

            // To generate a persistable assembly, specify AssemblyBuilderAccess.RunAndSave.
            AssemblyBuilder assemblyBuilder = myDomain.DefineDynamicAssembly(
                assemblyNameObject,
                AssemblyBuilderAccess.RunAndSave);

            // Generate a persistable single-module assembly.
            ModuleBuilder moduleBuilder =
                assemblyBuilder.DefineDynamicModule(assemblyNameObject.Name, assemblyNameObject.Name + ".dll");

            TypeBuilder myTypeBuilder =
                moduleBuilder
                .DefineType(
                    $"{assemblyName}.{typeName}",
                    TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.AutoLayout);

            this.moduleBuilder = moduleBuilder;
            this.typeBuilder = myTypeBuilder;
        }

        public ClassBuilder AddProperty(string name, Type returnType, Func<PropertyBuilder, PropertyBuilder> buildFunction)
        {
            var propertyBuilder = new PropertyBuilder(this.typeBuilder, name, returnType);
            buildFunction(propertyBuilder);
            propertyBuilder.Build();

            return this;
        }

        public ClassBuilder AddMethod(Func<MethodBuilder, MethodBuilder> buildFunction)
        {
            return this;
        }


        public Type BuildType()
        {
            return this.typeBuilder.CreateType();
        }
    }
}
