using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    public static class CompareGuardExtensions
    {
        public static CompareGuardFailedException GetCompareException<T>(this ICompareGuard<T> guard) where T : IComparable<T>
        {
            return new CompareGuardFailedException($"Subject is not {Enum.GetName(typeof(CompareGuardTypes), guard.CompareType)} than target");
        }
    }
}
