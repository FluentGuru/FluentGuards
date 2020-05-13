using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public interface IEnumerableGuard<T> : IGuard<IEnumerable<T>>
    {
    }
}
