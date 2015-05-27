using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class ExpressionTransformer<From, To> : ExpressionVisitor
    {
        public ParameterExpression NewParamExpr { get; private set; }

        public ExpressionTransformer(ParameterExpression newParamExpr)
        {
            NewParamExpr = newParamExpr;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return NewParamExpr;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(From))
                return Expression.MakeMemberAccess(this.Visit(node.Expression),
                   typeof(To).GetMember(node.Member.Name).FirstOrDefault());
            return base.VisitMember(node);
        }
    }

    //public static class ExpressionTransformer<From, To>
    //{
    //    public class Visitor : ExpressionVisitor
    //    {
    //        private ParameterExpression _parameter;

    //        public Visitor(ParameterExpression parameter)
    //        {
    //            _parameter = parameter;
    //        }

    //        protected override Expression VisitParameter(ParameterExpression node)
    //        {
    //            return _parameter;
    //        }
    //    }

    //    public static Expression<Func<To, bool>> Transform(Expression<Func<From, bool>> expression)
    //    {
    //        ParameterExpression parameter = Expression.Parameter(typeof(To));
    //        Expression body = new Visitor(parameter).Visit(expression.Body);
    //        return Expression.Lambda<Func<To, bool>>(body, parameter);
    //    }
    //}
}
