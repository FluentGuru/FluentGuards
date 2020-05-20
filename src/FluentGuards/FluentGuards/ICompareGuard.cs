using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public interface ICompareGuard<T> : IGuard<T> where T : IComparable<T>
    {
        CompareGuardTypes CompareType { get; }
    }

    public interface IAsyncCompareGuard<T> : ICompareGuard<T>, IAsyncGuard<T> where T : IComparable<T>
    {

    }
}
