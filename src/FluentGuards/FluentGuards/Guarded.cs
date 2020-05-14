using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{ 
    public readonly struct Guarded<T>
    {
        internal Guarded(T subject, bool isGuarded)
        {
            Subject = subject;
            IsGuarded = isGuarded;
        }

        public T Subject { get; }
        public bool IsGuarded { get; }

        public static implicit operator T(Guarded<T> guarded) => guarded.Subject;
        public static implicit operator bool(Guarded<T> guarded) => guarded.IsGuarded;

        public static implicit operator Guarded<T>(T subject) => new Guarded<T>(subject, true);
        public static implicit operator Guarded<T>(bool isGuarded) => new Guarded<T>(default, isGuarded);
    }
}
