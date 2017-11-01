﻿namespace JQDT.DataProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    internal class CommonFilter : IDataProcess
    {
        public static IQueryable<object> ProcessData(IQueryable<object> data, DataTableAjaxPostModel filterModel)
        {
            if (string.IsNullOrWhiteSpace(filterModel.search.value))
            {
                return data.Select(x => x);
            }

            var expr = BuildExpression(data.GetType().GetGenericArguments().First(), filterModel.search.value);
            data = data.Where(expr);
            return data;
        }

        private static Expression<Func<dynamic, bool>> BuildExpression(Type modelType, string search)
        {
            // x
            var modelParamExpr = Expression.Parameter(typeof(object), "model");
            var properties = ((System.Reflection.TypeInfo)modelType).DeclaredProperties;
            var containExpressionCollection = new List<MethodCallExpression>();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var currentPropertyContainsExpression = GetSinglePropertyExpression(modelType, search, propName, modelParamExpr);
                containExpressionCollection.Add(currentPropertyContainsExpression);
            }

            Expression orExpr = GetOrExpr(containExpressionCollection);

            var lambda = Expression.Lambda(orExpr, modelParamExpr);

            return (Expression<Func<dynamic, bool>>)lambda;
        }

        private static Expression GetOrExpr(List<MethodCallExpression> containExpressionCollection)
        {
            var numberOfExpressions = containExpressionCollection.Count;
            var counter = 0;
            Expression orExpr = null;
            do
            {
                orExpr = Expression.Or(orExpr ?? containExpressionCollection[counter], containExpressionCollection[counter + 1]);

                counter++;
            } while (counter < numberOfExpressions - 1);

            return orExpr;
        }

        // Returns the "Contains" expression for a single property
        private static MethodCallExpression GetSinglePropertyExpression(Type modelType, string search, string propName, ParameterExpression modelParamExpr)
        {
            // searchVal
            var searchValExpr = Expression.Constant(search.ToLower());
            // (TypeOfX)x
            var convertExpr = Expression.Convert(modelParamExpr, modelType);
            // x.Name
            var propExpr = Expression.Property(convertExpr, propName);
            // x.Name.ToString()
            var toStringMethodInfo = typeof(Object).GetMethod("ToString");
            var toStringExpr = Expression.Call(propExpr, toStringMethodInfo);
            // x.Name.ToString().ToLower()
            var toLowerMethodInfo = typeof(String).GetMethods().Where(m => m.Name == "ToLower" && !m.GetParameters().Any()).First();
            var toLowerExpr = Expression.Call(toStringExpr, toLowerMethodInfo);
            // x.Name.ToString().Contains()
            var containsMethodInfo = typeof(String).GetMethod("Contains");
            var containsExpr = Expression.Call(toLowerExpr, containsMethodInfo, searchValExpr);

            return containsExpr;
        }
    }
}