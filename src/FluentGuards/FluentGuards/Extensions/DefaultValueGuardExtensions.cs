using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public static class DefaultValueGuardExtensions
    {
        public static IGuard<T> Default<T>(this IGuard<T> guard, T value) =>
            new DefaultValueGuardDecorator<IGuard<T>, T>(value, guard);

        public static IAsyncGuard<T> Default<T>(this IAsyncGuard<T> guard, T value) =>
            new DefaultValueAsyncGuadDecorator<IAsyncGuard<T>, T>(value, guard);

    }
}
