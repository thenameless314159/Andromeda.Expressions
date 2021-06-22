using System;
using Andromeda.Expressions;
using FastExpressionCompiler;

namespace Andromeda.FastExpressions
{
    public class DefaultFastExpressionCompiler<TDelegate> : DefaultExpressionCompiler<TDelegate>
        where TDelegate : Delegate
    {
        public DefaultFastExpressionCompiler(CompilerFlags flags = CompilerFlags.Default, int? bodyCapacity = default) 
            : base(bodyCapacity) => _compilerFlags = flags;
        
        private readonly CompilerFlags _compilerFlags;

        // TODO: compile slow on failed ?
        public override TDelegate Compile() => Build().CompileFast(ifFastFailedReturnNull: false, _compilerFlags);
    }
}
