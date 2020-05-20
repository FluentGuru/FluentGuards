using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{ 
    /// <summary>
    /// A value representing the result of a guard
    /// </summary>
    /// <typeparam name="T">the type of the subject guarded</typeparam>
    public readonly struct Guarded<T>
    {
        /// <summary>
        /// Creates a new instance of Guarded
        /// </summary>
        /// <param name="subject"><see cref="Guarded{T}.Subject"/></param>
        /// <param name="isGuarded"><see cref="Guarded{T}.IsGuarded"/></param>
        internal Guarded(T subject, bool isGuarded)
        {
            Subject = subject;
            IsGuarded = isGuarded;
        }

        /// <summary>
        /// The subject guarded
        /// </summary>
        public T Subject { get; }
        /// <summary>
        /// True if the subject is guarded
        /// </summary>
        public bool IsGuarded { get; }

        public static implicit operator T(Guarded<T> guarded) => guarded.Subject;
        public static implicit operator bool(Guarded<T> guarded) => guarded.IsGuarded;

        public static implicit operator Guarded<T>(T subject) => new Guarded<T>(subject, true);
        public static implicit operator Guarded<T>(bool isGuarded) => new Guarded<T>(default, isGuarded);

    }
}
