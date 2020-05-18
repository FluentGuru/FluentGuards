using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ObjectGuardExtensions
    {
        

        public static IGuard<T> NotNull<T>(this T subject) where T : class
            => new SimpleGuard<T>(subject, s => s != null, new NotNullGuardFailedException("Subject cannot be null"));

        public static IAsyncGuard<T> NotNull<T>(this Task<T> subject) where T : class
            => new AsyncSimpleGuard<T>(subject, s => s != null, new NotNullGuardFailedException("Subject cannot be null"));
    }
}
