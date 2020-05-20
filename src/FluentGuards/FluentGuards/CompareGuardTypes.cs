using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// Represent the types of comparison that a comparison can guard
    /// </summary>
    public enum CompareGuardTypes
    {
        /// <summary>
        /// Specifies that the subject should be equal to the target
        /// </summary>
        Equals,
        /// <summary>
        /// Specifies that the subject should not be equal to the target
        /// </summary>
        NotEquals,
        /// <summary>
        /// Specifies that the subject should be greater than the target
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Specifies that the subject should be less than the target
        /// </summary>
        LessThan,
        /// <summary>
        /// Specifies that the subject should be greater or equal than the target
        /// </summary>
        GreaterOrEqualThan,
        /// <summary>
        /// Specifies that the subject should be less or equal than the target
        /// </summary>
        LessOrEqualThan,
    }
}
