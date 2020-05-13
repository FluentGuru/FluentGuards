using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards.Internals
{
    public abstract class AsyncGuardBase<T> : IAsyncGuard<T>
    {
        public AsyncGuardBase(Task<T> subject)
        {
            Subject = subject;
        }

        public Task<T> Subject { get; }

        public abstract Exception GetGuardException();

        public T Guard() => GuardAsync().GetAwaiter().GetResult();

        public async Task<T> GuardAsync()
        {
            var guarded = await TryGuardAsync();
            if(guarded)
            {
                return guarded;
            }

            throw GetGuardException();
        }

        public Guarded<T> TryGuard() => TryGuardAsync().GetAwaiter().GetResult();

        public abstract Task<Guarded<T>> TryGuardAsync();
    }
}
