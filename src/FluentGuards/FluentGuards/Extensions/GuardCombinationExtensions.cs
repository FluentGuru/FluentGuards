using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class GuardCombinationExtensions
    {
        public static IAsyncCombinedGuard<T> Combine<T>(this IAsyncGuard<T> guard, Func<Task<T>, IAsyncGuard<T>> predicate, GuardCombinationTypes type)
            => new AsyncCombinedGuard<T>(guard, predicate, type);

        public static ICombinedGuard<T> Combine<T>(this IGuard<T> guard, Func<T, IGuard<T>> predicate, GuardCombinationTypes type)
            => new CombinedGuard<T>(guard, predicate, type);

        public static IAsyncCombinedGuard<T> And<T>(this IAsyncGuard<T> guard, Func<Task<T>, IAsyncGuard<T>> predicate)
            => guard.Combine(predicate, GuardCombinationTypes.And);

        public static ICombinedGuard<T> And<T>(this IGuard<T> guard, Func<T, IGuard<T>> predicate)
            => guard.Combine(predicate, GuardCombinationTypes.And);

        public static IAsyncCombinedGuard<T> Or<T>(this IAsyncGuard<T> guard, Func<Task<T>, IAsyncGuard<T>> predicate)
            => guard.Combine(predicate, GuardCombinationTypes.Or);

        public static ICombinedGuard<T> Or<T>(this IGuard<T> guard, Func<T, IGuard<T>> predicate)
            => guard.Combine(predicate, GuardCombinationTypes.Or);
    }
}
