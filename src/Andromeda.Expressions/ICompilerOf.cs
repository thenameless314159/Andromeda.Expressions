using System;

namespace Andromeda.Expressions
{
    public interface ICompilerOf<out TDelegate> where TDelegate : Delegate
    {
        TDelegate Compile();
    }
}
