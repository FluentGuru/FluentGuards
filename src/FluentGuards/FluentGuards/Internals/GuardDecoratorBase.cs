using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal abstract class GuardDecoratorBase<TGuard, T> : IGuard<T> where TGuard : IGuard<T>
    {
        public GuardDecoratorBase(TGuard target)
        {
            Target = target;
        }

        public TGuard Target { get; }

        public virtual Exception GetGuardException() => Target.GetGuardException();

        public virtual T Guard() => Target.Guard();

        public Guarded<T> TryGuard() => Target.TryGuard();
    }

    internal abstract class AsyncGuardDecoratorBase<TGuard, T> : GuardDecoratorBase<TGuard, T>, IAsyncGuard<T>
        where TGuard : IAsyncGuard<T>
    {
        public AsyncGuardDecoratorBase(TGuard target) : base(target)
        {
        }

        public virtual Task<T> GuardAsync() => Target.GuardAsync();

        public virtual Task<Guarded<T>> TryGuardAsync() => Target.TryGuardAsync();
    }
}
