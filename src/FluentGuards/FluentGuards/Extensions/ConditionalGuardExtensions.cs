using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ConditionalGuardExtensions 
    {
        public static IGuard<T> Condition<T>(this T subject, Func<T, bool> predicate) =>
            new SimpleGuard<T>(subject, predicate, new ConditionalGuardFailedException("Conditional guard failed for subject"));

        public static IAsyncGuard<T> Condition<T>(this Task<T> subject, Func<T, bool> predicate) =>
            new AsyncSimpleGuard<T>(subject, predicate, new ConditionalGuardFailedException("Conditional guard failed for subject"));
    }
}
