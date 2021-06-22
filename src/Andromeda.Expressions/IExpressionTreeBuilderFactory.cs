using System;

namespace Andromeda.Expressions
{
    public interface IExpressionTreeBuilderFactory : IExpressionCompilerFactory
    {
        IExpressionTreeBuilder<TDelegate> Create<TDelegate>(int? maxBodyCapacity = default) where TDelegate : Delegate;
    }
}
