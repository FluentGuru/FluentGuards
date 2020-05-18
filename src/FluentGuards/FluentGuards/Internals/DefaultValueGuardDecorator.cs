using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class DefaultValueGuardDecorator<TGuard, T> : GuardDecoratorBase<TGuard, T> where TGuard : IGuard<T>
    {
        private readonly T defaultValue;

        public DefaultValueGuardDecorator(T defaultValue, TGuard target) : base(target)
        {
            this.defaultValue = defaultValue;
        }

        public override T Guard()
        {
            try
            {
                return base.Guard();
            }
            catch(Exception)
            {
                return defaultValue;
            }
        }
    }

    internal class DefaultValueAsyncGuadDecorator<TGuard, T> : AsyncGuardDecoratorBase<TGuard, T> where TGuard : IAsyncGuard<T>
    {
        private readonly T defaultValue;

        public DefaultValueAsyncGuadDecorator(T defaultValue, TGuard target) : base(target)
        {
            this.defaultValue = defaultValue;
        }

        public async override Task<T> GuardAsync()
        {
            try
            {
                return await base.GuardAsync();
            }
            catch(Exception)
            {
                return defaultValue;
            }
        }
    }
}
