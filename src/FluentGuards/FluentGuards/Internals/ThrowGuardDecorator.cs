using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public override T Guard()
        {
            try
            {
                return base.Guard();
            }
            catch(Exception)
            {
                throw exception;
            }
        }
    }

    internal class ThrowAsyncGuardDecorator<TGuard, T> : AsyncGuardDecoratorBase<TGuard, T>, IAsyncGuard<T> where TGuard : IAsyncGuard<T>
    {
        private readonly Exception exception;

        public ThrowAsyncGuardDecorator(Exception exception, TGuard target) : base(target)
        {
            this.exception = exception;
        }

        public override Exception GetGuardException() => exception;

        public async override Task<T> GuardAsync()
        {
            try
            {
                return await base.GuardAsync();
            }
            catch(Exception)
            {
                throw exception;
            }
        }
    }
}
