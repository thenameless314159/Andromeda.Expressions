using System;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;
using static System.Linq.Expressions.Expression;

namespace Andromeda.Expressions
{
    public class DefaultExpressionCompiler<TDelegate> : IExpressionTreeBuilder<TDelegate>
        where TDelegate : Delegate
    {
        private static readonly ParameterExpression[] _emptyParams = Array.Empty<ParameterExpression>();
        private static readonly List<ParameterExpression> _emptyParamExpressions = new(0);

        protected List<ParameterExpression> Parameters => _parameters ??= _emptyParamExpressions;
        protected List<ParameterExpression> Variables => _variables ??= _emptyParamExpressions;

        public DefaultExpressionCompiler(int? bodyCapacity = default) => _body = bodyCapacity.HasValue
            ? new List<Expression>(bodyCapacity.Value)
            : new List<Expression>();
        
        private List<ParameterExpression>? _parameters;
        private List<ParameterExpression>? _variables;
        protected readonly List<Expression> _body;

        public ParameterExpression? GetParameter(Predicate<ParameterExpression> selector) => 
            _parameters?.Find(selector) ?? null;

        public ParameterExpression? GetVariable(Predicate<ParameterExpression> selector) => 
            _variables?.Find(selector) ?? null;

        public IExpressionTree Parameter(Type type, string? name, out ParameterExpression expression) {
            _parameters ??= new List<ParameterExpression>();
            expression = Expression.Parameter(type, name);
            _parameters.Add(expression);
            return this;
        }

        public IExpressionTree Variable(Type type, string? name, out ParameterExpression expression) {
            _variables ??= new List<ParameterExpression>();
            expression = Expression.Variable(type, name);
            _variables.Add(expression);
            return this;
        }

        public IExpressionTree Emit(Expression expression) {
            _body.Add(expression);
            return this;
        }

        private Expression<TDelegate>? _cachedLambda;
        public Expression<TDelegate> Build() => _cachedLambda ??= 
            Lambda<TDelegate>(Variables.Count > 0 ? Block(Variables, _body) : Block(_body), 
                Parameters.Count > 0 ? Parameters.ToArray() : _emptyParams);

        public virtual TDelegate Compile() => Build().Compile();

        public IEnumerator<Expression> GetEnumerator() => _body.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
