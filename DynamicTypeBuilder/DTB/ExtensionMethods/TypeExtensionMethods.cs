namespace DTB.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class TypeExtensionMethods
    {
        public static Dictionary<string, object> cachedInstanceFunctions = new Dictionary<string, object>();

        public static T GetInstanceOf<T>(this Type type)
        {
            object instanceFunction = null;

            if (!cachedInstanceFunctions.TryGetValue(type.FullName, out instanceFunction))
            {
                var newExpression = Expression.New(type.GetConstructor(Type.EmptyTypes));
                var newLambdaExpression = Expression.Lambda<Func<T>>(newExpression);
                var newFunc = newLambdaExpression.Compile();

                cachedInstanceFunctions[type.FullName] = newFunc;
            }

            Func<T> castedInstanceFunction = (Func<T>)cachedInstanceFunctions[type.FullName];
            var instance = castedInstanceFunction();

            return instance;
        }
    }
}