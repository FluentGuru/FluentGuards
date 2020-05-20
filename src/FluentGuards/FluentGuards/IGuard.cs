using System;

namespace FluentGuards
{
    /// <summary>
    /// An object that will guard subject
    /// </summary>
    /// <typeparam name="T">Type of the subject to guard</typeparam>
    public interface IGuard<T>
    {
        /// <summary>
        /// Guards the subject and returns if successful
        /// </summary>
        /// <exception cref="GuardFailedException" />
        /// <returns>the subject guarded</returns>
        T Guard();
        /// <summary>
        /// Attempts to guard the subject
        /// </summary>
        /// <returns>an instance of <see cref="Guarded{T}"/> represeting the result of the guard</returns>
        Guarded<T> TryGuard();

        /// <summary>
        /// returns the exception that will be thrown if the guard fails
        /// </summary>
        /// <returns>the exception throw by the guard on failure</returns>
        Exception GetGuardException();
    }
}
