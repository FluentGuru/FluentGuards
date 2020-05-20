using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class CombinedGuard<T> : CombinedGuardBase<T>
    {
        private readonly IGuard<T> guard;
        private readonly Func<T, IGuard<T>> predicate;

        public CombinedGuard(IGuard<T> guard, Func<T, IGuard<T>> predicate, GuardCombinationTypes combinationType) : base(combinationType)
        {
            this.guard = guard;
            this.predicate = predicate;
        }

        public override Guarded<T> TryGuard()
        {
            var leftGuarded = guard.TryGuard();
            var rightGuarded = predicate(leftGuarded).TryGuard();
            var guarded = false;
            switch (CombinationType)
            {
                case GuardCombinationTypes.And:
                    guarded = leftGuarded && rightGuarded;
                    break;
                case GuardCombinationTypes.Or:
                default:
                    guarded = leftGuarded || rightGuarded;
                    break;
            }

            if(guarded)
            {
                return leftGuarded;
            }

            return guarded;
        }
    }

    internal class AsyncCombinedGuard<T> : AsyncCombinedGuardBase<T>
    {
        private readonly IAsyncGuard<T> guard;
        private readonly Func<T, IAsyncGuard<T>> predicate;

        public AsyncCombinedGuard(IAsyncGuard<T> guard, Func<T, IAsyncGuard<T>> predicate, GuardCombinationTypes combinationType) : base(combinationType)
        {
            this.guard = guard;
            this.predicate = predicate;
        }

        public override Guarded<T> TryGuard() => TryGuardAsync().GetAwaiter().GetResult();

        public async override Task<Guarded<T>> TryGuardAsync()
        {
            var leftGuarded = await guard.TryGuardAsync();
            var rightGuarded = await predicate(leftGuarded).TryGuardAsync();
            var guarded = false;
            switch (CombinationType)
            {
                case GuardCombinationTypes.And:
                    guarded = leftGuarded && rightGuarded;
                    break;
                case GuardCombinationTypes.Or:
                default:
                    guarded = leftGuarded || rightGuarded;
                    break;
            }

            if(guarded)
            {
                return leftGuarded;
            }

            return guarded;
        }
    }
}
