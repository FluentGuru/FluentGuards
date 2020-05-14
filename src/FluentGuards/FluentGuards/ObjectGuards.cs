using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ObjectGuards
    {
        public static IGuard<T> Throw<T>(IGuard<T> guard, Exception exception) => new ThrowGuardDecorator<IGuard<T>, T>(exception, guard);

        public static IAsyncGuard<T> Throw<T>(IAsyncGuard<T> guard, Exception exception) => new ThrowAsyncGuardDecorator<IAsyncGuard<T>, T>(exception, guard);

        public static IGuard<T> NotNull<T>(T subject) where T : class
            => new SimpleGuard<T>(subject, s => s != null, new ArgumentNullException("subject", "Subject cannot be null"));

        public static IAsyncGuard<T> NotNull<T>(Task<T> subject) where T : class
            => new AsyncSimpleGuard<T>(subject, s => s != null, new ArgumentNullException("subject", "Subject cannot be null"));
    }
}
