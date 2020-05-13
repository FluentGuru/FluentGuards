using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public interface IGuardDecorator<TGuard, T> : IGuard<T> where TGuard : IGuard<T>
    {
    }
}
