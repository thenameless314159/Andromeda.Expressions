using System;

namespace Andromeda.Expressions
{
    public interface IExpressionCompiler<TDelegate> : IExpressionBuilder<TDelegate>, ICompilerOf<TDelegate>
        where TDelegate : Delegate
    {
        new TDelegate Compile() => Build().Compile();
    }
}
