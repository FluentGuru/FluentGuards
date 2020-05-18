using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class DoNotThrowGuardDecorator<TGuard, T> : GuardDecoratorBase<TGuard, T> where TGuard : IGuard<T>
    {
        public DoNotThrowGuardDecorator(TGuard target) : base(target)
        {
        }

        public override T Guard()
        {
            try
            {
                return base.Guard();
            }
            catch(Exception)
            {
                return default;
            }
        }
    }

    internal class DoNotThrowAsyncGuardDecorator<TGuard, T> : AsyncGuardDecoratorBase<TGuard, T> where TGuard : IAsyncGuard<T>
    {
        public DoNotThrowAsyncGuardDecorator(TGuard target) : base(target)
        {
        }

        public override async Task<T> GuardAsync()
        {
            try
            {
                return await base.GuardAsync();
            }
            catch(Exception)
            {
                return default;
            }
        }
    }
}
