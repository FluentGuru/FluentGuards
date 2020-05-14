using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    internal class ThrowGuardDecorator<TGuard, T> : GuardDecoratorBase<TGuard, T>, IGuard<T> where TGuard : IGuard<T>
    {
        private readonly Exception exception;

        public ThrowGuardDecorator(Exception exception, TGuard target) : base(target)
        {
            this.exception = exception;
        }

        public override Exception GetGuardException() => exception;
    }

    internal class ThrowAsyncGuardDecorator<TGuard, T> : AsyncGuardDecoratorBase<TGuard, T>, IAsyncGuard<T> where TGuard : IAsyncGuard<T>
    {
        private readonly Exception exception;

        public ThrowAsyncGuardDecorator(Exception exception, TGuard target) : base(target)
        {
            this.exception = exception;
        }

        public override Exception GetGuardException() => exception;
    }
}
