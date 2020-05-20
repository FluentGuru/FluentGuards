using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ObjectGuardExtensions
    {
        public static IGuard<T> Guard<T>(this T subject, Func<T, bool> predicate, Exception exception)
            => new SimpleGuard<T>(subject, predicate, exception);

        public static IAsyncGuard<T> GuardAsync<T>(this Task<T> subject, Func<T, bool> predicate, Exception exception)
            => new AsyncSimpleGuard<T>(subject, predicate, exception);
        

        public static IGuard<T> NotNull<T>(this T subject) where T : class
            => subject.Guard(s => s != null, new NotNullGuardFailedException("Subject cannot be null"));

        public static IAsyncGuard<T> NotNull<T>(this Task<T> subject) where T : class
            => subject.GuardAsync(s => s != null, new NotNullGuardFailedException("Subject cannot be null"));
    }
}
