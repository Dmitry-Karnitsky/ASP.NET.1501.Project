using System;
using System.Linq.Expressions;

namespace Helpers
{
    public static class ExpressionTransformer<From, To>
    {
        public class Visitor : ExpressionVisitor
        {
            private ParameterExpression _parameter;

            public Visitor(ParameterExpression parameter)
            {
                _parameter = parameter;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _parameter;
            }
        }

        public static Expression<Func<To, bool>> Transform(Expression<Func<From, bool>> expression)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(To));
            Expression body = new Visitor(parameter).Visit(expression.Body);
            return Expression.Lambda<Func<To, bool>>(body, parameter);
        }
    }
}
