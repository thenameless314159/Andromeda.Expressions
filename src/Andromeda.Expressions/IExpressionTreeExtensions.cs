using System;
using System.Linq.Expressions;

namespace Andromeda.Expressions
{
    public static class IExpressionTreeExtensions
    {
        public static IExpressionTree Parameter<T>(this IExpressionTree expr, out ParameterExpression expression) => 
            expr.Parameter(typeof(T), default, out expression);

        public static IExpressionTree Variable<T>(this IExpressionTree expr, out ParameterExpression expression) => 
            expr.Variable(typeof(T), default, out expression);
        
        public static IExpressionTree Parameter<T>(this IExpressionTree expr, string? name,
            out ParameterExpression expression) => expr.Parameter(typeof(T), name, out expression);

        public static IExpressionTree Variable<T>(this IExpressionTree expr, string? name,
            out ParameterExpression expression) => expr.Variable(typeof(T), name, out expression);

        public static ParameterExpression? GetParameter(this IExpressionTree expr, string byName) => 
            expr.GetParameter(p => p.Name == byName);

        public static ParameterExpression? GetVariable(this IExpressionTree expr, string byName) =>
            expr.GetVariable(p => p.Name == byName);

        public static ParameterExpression? GetParameter(this IExpressionTree expr, Type byType) =>
            expr.GetParameter(p => p.Type == byType);

        public static ParameterExpression? GetVariable(this IExpressionTree expr, Type byType) =>
            expr.GetVariable(p => p.Type == byType);

        public static ParameterExpression? GetParameter<T>(this IExpressionTree expr) =>
            expr.GetParameter(p => p.Type == typeof(T));

        public static ParameterExpression? GetVariable<T>(this IExpressionTree expr) =>
            expr.GetVariable(p => p.Type == typeof(T));
    }
}
