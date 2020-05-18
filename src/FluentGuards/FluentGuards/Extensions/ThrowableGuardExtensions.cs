using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public static class ThrowableGuardExtensions
    {
        public static IGuard<T> Throw<T>(this IGuard<T> guard, Exception exception) => new ThrowGuardDecorator<IGuard<T>, T>(exception, guard);

        public static IAsyncGuard<T> Throw<T>(this IAsyncGuard<T> guard, Exception exception) => new ThrowAsyncGuardDecorator<IAsyncGuard<T>, T>(exception, guard);

        public static IGuard<T> DoNotThrow<T>(this IGuard<T> guard) => new DoNotThrowGuardDecorator<IGuard<T>, T>(guard);

        public static IAsyncGuard<T> DoNotThrow<T>(this IAsyncGuard<T> guard) => new DoNotThrowAsyncGuardDecorator<IAsyncGuard<T>, T>(guard);
    }
}
