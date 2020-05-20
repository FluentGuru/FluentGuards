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
            switch (CombinationType)
            {
                case GuardCombinationTypes c when (c == GuardCombinationTypes.And && (leftGuarded && predicate(leftGuarded).TryGuard())):
                    return leftGuarded;
                case GuardCombinationTypes c when (c == GuardCombinationTypes.Or && (leftGuarded || predicate(leftGuarded).TryGuard())):
                    return leftGuarded;
                default:
                    return false;
            }
        }
    }

    internal class AsyncCombinedGuard<T> : AsyncCombinedGuardBase<T>
    {
        private readonly IAsyncGuard<T> guard;
        private readonly Func<Task<T>, IAsyncGuard<T>> predicate;

        public AsyncCombinedGuard(IAsyncGuard<T> guard, Func<Task<T>, IAsyncGuard<T>> predicate, GuardCombinationTypes combinationType) : base(combinationType)
        {
            this.guard = guard;
            this.predicate = predicate;
        }

        public override Guarded<T> TryGuard() => TryGuardAsync().GetAwaiter().GetResult();

        public async override Task<Guarded<T>> TryGuardAsync()
        {
            var leftGuardedTask = guard.TryGuardAsync();
            var leftSubject = leftGuardedTask.AsSubjectTask();
            var leftGuarded = await leftGuardedTask;
            switch (CombinationType)
            {
                case GuardCombinationTypes c when (c == GuardCombinationTypes.And && (leftGuarded && await predicate(leftSubject).TryGuardAsync())):
                    return leftGuarded;
                case GuardCombinationTypes c when (c == GuardCombinationTypes.Or && (leftGuarded || await predicate(leftSubject).TryGuardAsync())):
                    return leftGuarded;
                default:
                    return false;
            }
        }
    }
}
