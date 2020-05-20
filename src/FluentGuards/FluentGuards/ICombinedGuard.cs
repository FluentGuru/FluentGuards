using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public interface ICombinedGuard<T> : IGuard<T>
    {
        GuardCombinationTypes CombinationType { get; }
    }

    public interface IAsyncCombinedGuard<T> : ICombinedGuard<T>, IAsyncGuard<T>
    {

    }
}
