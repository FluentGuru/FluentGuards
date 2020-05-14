using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ObjectGuardExtensions
    {
        public static IGuard<T> Throw<T>(this IGuard<T> guard, Exception exception) => new ThrowGuardDecorator<IGuard<T>, T>(exception, guard);

        public static IAsyncGuard<T> Throw<T>(this IAsyncGuard<T> guard, Exception exception) => new ThrowAsyncGuardDecorator<IAsyncGuard<T>, T>(exception, guard);

        public static IGuard<T> NotNull<T>(this T subject) where T : class
            => new SimpleGuard<T>(subject, s => s != null, new ArgumentNullException("subject", "Subject cannot be null"));

        public static IAsyncGuard<T> NotNull<T>(this Task<T> subject) where T : class
            => new AsyncSimpleGuard<T>(subject, s => s != null, new ArgumentNullException("subject", "Subject cannot be null"));
    }
}
