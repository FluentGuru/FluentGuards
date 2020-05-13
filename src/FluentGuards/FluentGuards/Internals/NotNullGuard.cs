using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.Internals
{
    internal class ObjectNotNullGuard<T> : GuardBase<T> where T : class
    {
        public ObjectNotNullGuard(T subject) : base(subject)
        {
        }

        public override Exception GetGuardException() => new ArgumentNullException($"Subject of type {typeof(T).FullName}");

        public override Guarded<T> TryGuard()
        {
            if(Subject != null)
            {
                return Subject;
            }

            return false;
        }
    }
}
