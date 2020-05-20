using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    /// <summary>
    /// An object that will guard an asynchronous subject
    /// </summary>
    /// <typeparam name="T">the type of the subject</typeparam>
    public interface IAsyncGuard<T> : IGuard<T>
    {
        /// <summary>
        /// Executes the guard on the subject asynchronously 
        /// </summary>
        /// <see cref="IGuard{T}.Guard"/>
        Task<T> GuardAsync();
        /// <summary>
        /// Attempts to guard the subject asynchronously
        /// </summary>
        /// <see cref="IGuard{T}.TryGuard"/>
        Task<Guarded<T>> TryGuardAsync();
    }
}
