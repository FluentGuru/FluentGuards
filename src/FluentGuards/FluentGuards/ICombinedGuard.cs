using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// An object that combines multiple guards into a single guard
    /// </summary>
    /// <see cref="IGuard{T}"/>
    public interface ICombinedGuard<T> : IGuard<T>
    {
        /// <summary>
        /// The combination mode of the guard
        /// </summary>
        GuardCombinationModes Mode { get; }
    }

    /// <summary>
    /// An object that asynchroniosly combine multiple guards into a single guard
    /// </summary>
    /// <see cref="ICombinedGuard{T}"/>
    public interface IAsyncCombinedGuard<T> : ICombinedGuard<T>, IAsyncGuard<T>
    {

    }
}
