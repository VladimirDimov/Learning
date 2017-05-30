//namespace ActionInjectionDemo.DI
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Web.Http.Dependencies;
//    using Autofac;

//    public class DependencyResolver : IDependencyResolver
//    {
//        private IContainer container;

//        public DependencyResolver(IContainer container)
//        {
//            this.container = container;
//        }

//        public IDependencyScope BeginScope()
//        {
//            return this.container.scope();
//        }

//        public void Dispose()
//        {
//        }

//        public object GetService(Type serviceType)
//        {
//            return this.container.Resolve(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return null;
//        }
//    }
//}