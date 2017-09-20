namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using DTB;
    using NUnit.Framework;

    public class PropertyGetterTests
    {
        private const string TEST_CLASS_NAME = "TestClassName";
        private const string TEST_ASSEMBLY_NAME = "TestAssemblyName";

        [Test]
        public void ShouldBeAbleToAddSinglePropertyWithAGetter()
        {
            string propName = "TestPropertyName";

            var types = new List<Type>()
            {
                new ClassBuilder(TEST_CLASS_NAME, AppDomain.CurrentDomain, TEST_ASSEMBLY_NAME)
                .AddProperty(propName, typeof(string), pb => pb.SetGetter(MethodAttributes.Public).SetSetter(MethodAttributes.Public).UseField())
                .BuildType(),

                new ClassBuilder(TEST_CLASS_NAME, AppDomain.CurrentDomain, TEST_ASSEMBLY_NAME)
                .AddProperty(propName, typeof(string), pb => pb.SetGetter(MethodAttributes.Public).SetSetter(MethodAttributes.Private))
                .BuildType(),

                new ClassBuilder(TEST_CLASS_NAME, AppDomain.CurrentDomain, TEST_ASSEMBLY_NAME)
                .AddProperty(propName, typeof(string), pb => pb.SetGetter(MethodAttributes.Public).UseField())
                .BuildType(),

                new ClassBuilder(TEST_CLASS_NAME, AppDomain.CurrentDomain, TEST_ASSEMBLY_NAME)
                .AddProperty(propName, typeof(string), pb => pb.SetGetter(MethodAttributes.Public))
                .BuildType(),
            };

            foreach (var type in types)
            {
                AssertShouldBeAbleToAddSinglePropertyWithAGetter(propName, type);
            }
        }

        private void AssertShouldBeAbleToAddSinglePropertyWithAGetter(string propertyName, Type type)
        {
            var typeProperties = ((TypeInfo)type).DeclaredProperties;
            Assert.True(type.Name == TEST_CLASS_NAME);
            Assert.True(typeProperties.Count() == 1);
            Assert.True(typeProperties.First().Name == propertyName);
        }
    }
}