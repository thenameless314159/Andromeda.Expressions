using Xunit;
using System;
using Xunit.Abstractions;
using FastExpressionCompiler;
using static System.Linq.Expressions.Expression;

namespace Andromeda.Expressions.Tests
{
    public class ExpressionTreeBuilderTests
    {
        public ExpressionTreeBuilderTests(ITestOutputHelper logger) => _logger = logger;
        private readonly ITestOutputHelper _logger;

        [Fact]
        public void CompileSumExpression_ShouldReturnSum()
        {
            var expression = CreateCompiler<Func<int, int, int>>();
            expression.Parameter(typeof(int), "left", out var left)
                .Parameter(typeof(int), "right", out var right)
                .Emit(Add(left, right));

            LogExpression(expression);
            Assert.Single(expression);
            Assert.Equal(10, expression.Compile()(5, 5));
        }

        protected virtual IExpressionTreeBuilder<TDel> CreateCompiler<TDel>() where TDel : Delegate =>
            new DefaultExpressionCompiler<TDel>();

        private void LogExpression<TDel>(IExpressionBuilder<TDel> expr) where TDel : Delegate
        {
            var lambda = expr.Build(); 
            _logger.WriteLine(lambda.ToCSharpString());
            _logger.WriteLine(string.Empty);
            _logger.WriteLine(lambda.ToExpressionString());
        }
    }
}
