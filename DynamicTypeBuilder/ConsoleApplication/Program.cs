namespace ConsoleApplication
{
    using System;
    using System.Reflection;
    using DTB;
    using DTB.ExtensionMethods;

    internal class Program
    {
        private static void Main()
        {
            var type = new ClassBuilder("testType", AppDomain.CurrentDomain, "TestAssemblyName")
                .AddProperty("Prop1", typeof(string), pb => pb.SetGetter(MethodAttributes.Public).SetSetter(MethodAttributes.Public).UseField())
                .AddMethod(mb => mb
                    .SetName("Method1"))
                .BuildType();

            var instance = type.GetInstanceOf<dynamic>();
            instance.Prop1 = "some test value";
        }
    }
}