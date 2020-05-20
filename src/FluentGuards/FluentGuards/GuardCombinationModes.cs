using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// Represent the modes available to combine guards
    /// </summary>
    public enum GuardCombinationModes
    {
        /// <summary>
        /// Specifies an AND combination mode
        /// </summary>
        And,
        /// <summary>
        /// Specifies an OR combination mode
        /// </summary>
        Or
    }
}
