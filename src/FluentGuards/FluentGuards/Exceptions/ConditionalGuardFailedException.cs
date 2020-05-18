using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class ConditionalGuardFailedException : GuardFailedException
    {
        public ConditionalGuardFailedException()
        {
        }

        public ConditionalGuardFailedException(string message) : base(message)
        {
        }

        public ConditionalGuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConditionalGuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
