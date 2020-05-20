using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    internal static class CompareGuardExtensions
    {
        public static CompareGuardFailedException GetCompareException<T>(this ICompareGuard<T> guard) where T : IComparable<T>
        {
            return new CompareGuardFailedException($"Subject is not {Enum.GetName(typeof(CompareGuardTypes), guard.CompareType)} than target");
        }

        public static bool IsMatch<T>(this T subject, T target, CompareGuardTypes compareType) where T : IComparable<T>
        {
            var compare = subject.CompareTo(target);
            switch (compareType)
            {
                case CompareGuardTypes.GreaterThan:
                    return compare > 0;
                case CompareGuardTypes.Equals:
                    return compare == 0;
                case CompareGuardTypes.NotEquals:
                    return compare != 0;
                case CompareGuardTypes.LessThan:
                    return compare < 0;
                case CompareGuardTypes.GreaterOrEqualThan:
                    return compare >= 0;
                case CompareGuardTypes.LessOrEqualThan:
                default:
                    return compare <= 0;
            }
        }
    }
}
