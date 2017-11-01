namespace JQDT.DataProcessing
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal class OrderProcessor : IDataProcess
    {
        public static IQueryable<object> ProcessData(IQueryable<object> data, DataTableAjaxPostModel filterModel)
        {
            var modelType = data.First().GetType(); // TODO: Improve this !!!
            IQueryable<object> orderedData = data.Select(x => x);
            var isFirst = true;
            foreach (var orderColumn in filterModel.order)
            {
                var colName = filterModel.columns[orderColumn.column].data;
                var isAsc = orderColumn.dir == "asc";
                var propType = modelType.GetProperty(colName).PropertyType;

                var lambdaExpr = OrderByExpression(propType, isAsc, isFirst);
                var propertySelectExpr = GetPropertySelectExpression(modelType, colName);
                orderedData = (IQueryable<object>)lambdaExpr.Compile().DynamicInvoke(data, propertySelectExpr);

                isFirst = false;
            }

            return orderedData;
        }

        private static LambdaExpression GetPropertySelectExpression(Type modelType, string propertyName)
        {
            // x
            ParameterExpression xExpr = Expression.Parameter(typeof(object), "x");
            // (ModelType)x
            var castExpr = Expression.Convert(xExpr, modelType);
            // (ModelType)x.Property
            var propExpression = Expression.Property(castExpr, propertyName);
            // x => (ModelType)x.Property
            var lambda = Expression.Lambda(propExpression, xExpr);

            return lambda;
        }

        private static LambdaExpression OrderByExpression(Type propType, bool isAsending, bool isFirst)
        {
            // data, selector => data.OrderBy(selector)
            // data
            var dataType = typeof(IQueryable<>).MakeGenericType(typeof(object));
            var dataExpr = Expression.Parameter(dataType, "x");
            // selector
            var funcGenericType = typeof(Func<,>).MakeGenericType(typeof(object), propType);
            var selectorParamExpr = Expression.Parameter(typeof(Expression<>).MakeGenericType(funcGenericType), "selector");
            // data.OrderBy(selector)
            var methodPrefix = isFirst ? "OrderBy" : "ThenBy";
            var methodSuffix = isAsending ? string.Empty : "Descending";
            var orderMethodName = $"{methodPrefix}{methodSuffix}";
            // TODO: Extract ThenBy on separate method. ThenBy is applied on IOrderedQueryable
            var orderByExpr = Expression.Call(typeof(Queryable), orderMethodName, new Type[] { typeof(object), propType }, dataExpr, selectorParamExpr);
            // data, selector => data.OrderBy(selector)
            var lambda = Expression.Lambda(orderByExpr, dataExpr, selectorParamExpr);

            return lambda;
        }
    }
}