using System;

namespace Andromeda.Expressions
{
    public interface IExpressionTreeBuilder<TDelegate> : IExpressionCompiler<TDelegate>, IExpressionTree
        where TDelegate : Delegate
    {
    }
}
