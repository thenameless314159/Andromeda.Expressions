using System;

namespace Andromeda.Expressions
{
    public class DefaultExpressionCompilerFactory : IExpressionTreeBuilderFactory
    {
        public DefaultExpressionCompilerFactory(int? cachedMaxBodyCapacity = default) => 
            _cachedMaxBodyCapacity = cachedMaxBodyCapacity;

        private readonly int? _cachedMaxBodyCapacity;

        public IExpressionTreeBuilder<TDelegate> Create<TDelegate>(int? maxBodyCapacity = default) where TDelegate : Delegate =>
            new DefaultExpressionCompiler<TDelegate>(_cachedMaxBodyCapacity ?? maxBodyCapacity);

        public IExpressionCompiler<TDelegate> Create<TDelegate>(Action<IExpressionTree>? configure) where TDelegate : Delegate {
            var builder = new DefaultExpressionCompiler<TDelegate>(_cachedMaxBodyCapacity);
            configure?.Invoke(builder);
            return builder;
        }
    }
}
