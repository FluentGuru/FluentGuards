using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class CombinedGuard<T> : CombinedGuardBase<T>
    {
        private readonly IGuard<T> guard;
        private readonly IGuard<T> target;

        public CombinedGuard(IGuard<T> guard, IGuard<T> target, GuardCombinationModes combinationType) : base(combinationType)
        {
            this.guard = guard;
            this.target = target;
        }

        public override Guarded<T> TryGuard()
        {
            var leftGuarded = guard.TryGuard();
            var rightGuarded = target.TryGuard();
            switch (Mode)
            {
                case GuardCombinationModes c when (c == GuardCombinationModes.And && (leftGuarded && rightGuarded)):
                    return leftGuarded ? leftGuarded : rightGuarded;
                case GuardCombinationModes c when (c == GuardCombinationModes.Or && (leftGuarded || rightGuarded)):
                    return leftGuarded ? leftGuarded : rightGuarded;
                default:
                    return false;
            }
        }
    }

    internal class AsyncCombinedGuard<T> : AsyncCombinedGuardBase<T>
    {
        private readonly IAsyncGuard<T> guard;
        private readonly IAsyncGuard<T> target;

        public AsyncCombinedGuard(IAsyncGuard<T> guard, IAsyncGuard<T> target, GuardCombinationModes combinationType) : base(combinationType)
        {
            this.guard = guard;
            this.target = target;
        }

        public override Guarded<T> TryGuard() => TryGuardAsync().GetAwaiter().GetResult();

        public async override Task<Guarded<T>> TryGuardAsync()
        {
            var leftGuarded = await guard.TryGuardAsync();
            var rightGuarded = await target.TryGuardAsync();
            switch (Mode)
            {
                case GuardCombinationModes c when (c == GuardCombinationModes.And && (leftGuarded && rightGuarded)):
                    return leftGuarded ? leftGuarded : rightGuarded;
                case GuardCombinationModes c when (c == GuardCombinationModes.Or && (leftGuarded || rightGuarded)):
                    return leftGuarded ? leftGuarded : rightGuarded;
                default:
                    return false;
            }
        }
    }
}
