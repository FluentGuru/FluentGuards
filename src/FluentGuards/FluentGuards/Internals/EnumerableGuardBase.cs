using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards.Internals
{
    internal abstract class EnumerableGuardBase<T> : GuardBase<IEnumerable<T>>, IEnumerableGuard<T>
    {
        public EnumerableGuardBase(IEnumerable<T> subject) : base(subject)
        {
        }
    }
}
