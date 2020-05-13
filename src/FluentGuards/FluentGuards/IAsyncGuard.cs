using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public interface IAsyncGuard<T> : IGuard<T>
    {
        Task<T> GuardAsync();
        Task<Guarded<T>> TryGuardAsync();
    }
}
