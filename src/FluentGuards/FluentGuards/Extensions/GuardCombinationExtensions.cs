using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class GuardCombinationExtensions
    {
        public static IAsyncCombinedGuard<T> Combine<T>(this IAsyncGuard<T> guard, IAsyncGuard<T> target, GuardCombinationModes type)
            => new AsyncCombinedGuard<T>(guard, target, type);

        public static ICombinedGuard<T> Combine<T>(this IGuard<T> guard, IGuard<T> target, GuardCombinationModes type)
            => new CombinedGuard<T>(guard, target, type);

        public static IAsyncCombinedGuard<T> And<T>(this IAsyncGuard<T> guard, IAsyncGuard<T> target)
            => guard.Combine(target, GuardCombinationModes.And);

        public static ICombinedGuard<T> And<T>(this IGuard<T> guard, IGuard<T> target)
            => guard.Combine(target, GuardCombinationModes.And);

        public static IAsyncCombinedGuard<T> Or<T>(this IAsyncGuard<T> guard, IAsyncGuard<T> target)
            => guard.Combine(target, GuardCombinationModes.Or);

        public static ICombinedGuard<T> Or<T>(this IGuard<T> guard, IGuard<T> target)
            => guard.Combine(target, GuardCombinationModes.Or);
    }
}
