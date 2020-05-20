using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ConditionalGuardExtensions 
    {
        public static IGuard<T> Condition<T>(this T subject, Func<T, bool> predicate) =>
            subject.Guard(predicate, new ConditionalGuardFailedException("Conditional guard failed for subject"));

        public static IAsyncGuard<T> Condition<T>(this Task<T> subject, Func<T, bool> predicate) =>
            subject.GuardAsync(predicate, new ConditionalGuardFailedException("Conditional guard failed for subject"));
    }
}
