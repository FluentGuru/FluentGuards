using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// An object that guards an object against comparison rules
    /// </summary>
    /// <see cref="IGuard{T}"/>
    public interface ICompareGuard<T> : IGuard<T> where T : IComparable<T>
    {
        /// <summary>
        /// The type of comparison being executed by the guard
        /// </summary>
        CompareGuardTypes CompareType { get; }
    }

    /// <summary>
    /// An object that guards an async operation against comparison rules
    /// </summary>
    /// <see cref="ICompareGuard{T}"/>
    public interface IAsyncCompareGuard<T> : ICompareGuard<T>, IAsyncGuard<T> where T : IComparable<T>
    {

    }
}
