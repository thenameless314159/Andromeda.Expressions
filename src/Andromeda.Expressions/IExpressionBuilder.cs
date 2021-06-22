using System;
using System.Linq.Expressions;

namespace Andromeda.Expressions
{
    public interface IExpressionBuilder<TDelegate> where TDelegate : Delegate
    {
        Expression<TDelegate> Build();
    }
}
