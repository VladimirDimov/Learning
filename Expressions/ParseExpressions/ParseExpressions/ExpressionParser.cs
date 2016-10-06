namespace ParseExpressions
{
    using System;
    using System.Linq.Expressions;

    public static class ExpressionParser
    {
        public static string Parse(string str)
        {
            return str;
        }

        public static string Parse<T>(Expression<Func<T, object>> expr)
        {
            return ParseExpr<T>(expr);
        }

        private static string ParseExpr<T>(Expression expr)
        {
            if (expr.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)expr;
                return ParseExpr<T>(lambda.Body);
            }
            else if (expr.NodeType == ExpressionType.Convert)
            {
                var convertExpr = (UnaryExpression)expr;

                return ParseExpr<T>(convertExpr.Operand);
            }
            else if (expr.NodeType == ExpressionType.Constant)
            {
                var constant = (ConstantExpression)expr;

                return constant.Value.ToString();
            }
            else if (expr.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpr = (MemberExpression)expr;
                var member = memberExpr.Member;

                if (member.ReflectedType == typeof(T))
                {
                    return memberExpr.Member.Name;
                }

                var lambda = Expression.Lambda(memberExpr);

                return Expression.Lambda(memberExpr).Compile().DynamicInvoke().ToString();
            }

            return expr.NodeType.ToString();
        }
    }
}
