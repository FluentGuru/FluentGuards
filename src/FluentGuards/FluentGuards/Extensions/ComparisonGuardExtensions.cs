using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ComparisonGuardExtensions
    {
        public static ICompareGuard<T> Compare<T>(this T subject, T target, CompareGuardTypes compareType) where T : IComparable<T>
            => new CompareGuard<T>(subject, target, compareType);

        public static IAsyncCompareGuard<T> Compare<T>(this Task<T> subject, T target, CompareGuardTypes compareType) where T : IComparable<T>
            => new AsyncCompareGuard<T>(subject, target, compareType);

        public static ICompareGuard<T> EqualsTo<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.Equals);

        public static IAsyncCompareGuard<T> EqualsTo<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.Equals);

        public static ICompareGuard<T> GreaterThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterThan);

        public static IAsyncCompareGuard<T> GreaterThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterThan);

        public static ICompareGuard<T> LessThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessThan);

        public static IAsyncCompareGuard<T> LessThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessThan);

        public static ICompareGuard<T> GreaterOrEqualThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterOrEqualThan);

        public static IAsyncCompareGuard<T> GreaterOrEqualThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterOrEqualThan);

        public static ICompareGuard<T> LessOrEqualThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessOrEqualThan);

        public static IAsyncCompareGuard<T> LessOrEqualThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessOrEqualThan);
    }
}
