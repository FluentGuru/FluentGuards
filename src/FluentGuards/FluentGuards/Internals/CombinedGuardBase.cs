using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal abstract class CombinedGuardBase<T> : ICombinedGuard<T>
    {
        public GuardCombinationTypes CombinationType { get; }


        public CombinedGuardBase(GuardCombinationTypes combinationType)
        {
            CombinationType = combinationType;
        }

        public virtual Exception GetGuardException() => new CombinedGuardFailedException("Combined guard failed");

        public T Guard()
        {
            var guarded = TryGuard();
            if(guarded)
            {
                return guarded;
            }

            throw GetGuardException();
        }

        public abstract Guarded<T> TryGuard();
    }

    internal abstract class AsyncCombinedGuardBase<T> : CombinedGuardBase<T>, IAsyncCombinedGuard<T>
    {
        public AsyncCombinedGuardBase(GuardCombinationTypes combinationType) : base(combinationType)
        {
        }

        public async Task<T> GuardAsync()
        {
            var guarded = await TryGuardAsync().ConfigureAwait(false);
            if(guarded)
            {
                return guarded;
            }

            throw GetGuardException();
        }

        public abstract Task<Guarded<T>> TryGuardAsync();
    }
}
