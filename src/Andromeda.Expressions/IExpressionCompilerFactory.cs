using System;

namespace Andromeda.Expressions
{
    public interface IExpressionCompilerFactory
    {
        IExpressionCompiler<TDelegate> Create<TDelegate>(Action<IExpressionTree>? configure) 
            where TDelegate : Delegate;
    }
}
