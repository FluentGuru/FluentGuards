using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards.Internals
{
    internal abstract class GuardBase<T> : IGuard<T>
    {
        public GuardBase(T subject)
        {
            Subject = subject;
        }

        public T Subject { get; }

        public abstract Exception GetGuardException();

        public virtual T Guard()
        {
            if(TryGuard())
            {
                return Subject;
            }

            throw GetGuardException();
        }

        public abstract Guarded<T> TryGuard();
    }
}
