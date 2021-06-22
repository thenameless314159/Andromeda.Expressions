using System;
using Andromeda.Expressions;
using FastExpressionCompiler;

namespace Andromeda.FastExpressions
{
    public class DefaultFastExpressionCompilerFactory : IExpressionTreeBuilderFactory
    {
        public DefaultFastExpressionCompilerFactory(CompilerFlags flags, int? cachedMaxBodyCapacity = default) =>
            (_cachedMaxBodyCapacity, _flags) = (cachedMaxBodyCapacity, flags);

        private readonly int? _cachedMaxBodyCapacity;
        private readonly CompilerFlags _flags;

        public IExpressionTreeBuilder<TDelegate> Create<TDelegate>(int? maxBodyCapacity = default)
            where TDelegate : Delegate =>
            new DefaultFastExpressionCompiler<TDelegate>(_flags, _cachedMaxBodyCapacity ?? maxBodyCapacity);

        public IExpressionCompiler<TDelegate> Create<TDelegate>(Action<IExpressionTree>? configure)
            where TDelegate : Delegate
        {
            var builder = new DefaultFastExpressionCompiler<TDelegate>(_flags, _cachedMaxBodyCapacity);
            configure?.Invoke(builder);
            return builder;
        }
    }
}
