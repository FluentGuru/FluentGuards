using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    [Flags]
    public enum CompareGuardTypes : int
    {
        GreaterThan = 1,
        Equals = 0,
        LessThan = -1,
        GreaterOrEqualThan = GreaterThan | Equals,
        LessOrEqualThan = LessThan | Equals
    }
}
