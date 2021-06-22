using Andromeda.FastExpressions;
using FastExpressionCompiler;
using Xunit.Abstractions;

namespace Andromeda.Expressions.Tests
{
    public class FastExpressionTreeBuilderTests : ExpressionTreeBuilderTests
    {
        public FastExpressionTreeBuilderTests(ITestOutputHelper logger) : base(logger)
        {
        }

        protected override IExpressionTreeBuilder<TDel> CreateCompiler<TDel>() =>
            new DefaultFastExpressionCompiler<TDel>(CompilerFlags.EnableDelegateDebugInfo);
    }
}
