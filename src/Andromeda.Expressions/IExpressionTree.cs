using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Andromeda.Expressions
{
    /// <summary>
    /// <see cref="Expression"/> based wrapper around the BCL to create expression trees.
    /// </summary>
    public interface IExpressionTree : IEnumerable<Expression>
    {
        IExpressionTree Parameter(Type type, string? name, out ParameterExpression expression);
        IExpressionTree Variable(Type type, string? name, out ParameterExpression expression);
        ParameterExpression? GetParameter(Predicate<ParameterExpression> selector);
        ParameterExpression? GetVariable(Predicate<ParameterExpression> selector);
       
        /// <summary>
        /// Emit an <see cref="Expression"/> to the body of the currently build expression tree.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> emitted to the body of the expression tree.</param>
        /// <returns>A self instance to allow call chaining.</returns>
        IExpressionTree Emit(Expression expression);
    }
}
