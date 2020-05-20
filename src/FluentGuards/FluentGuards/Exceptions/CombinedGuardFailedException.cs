using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class CombinedGuardFailedException : GuardFailedException
    {
        public CombinedGuardFailedException()
        {
        }

        public CombinedGuardFailedException(string message) : base(message)
        {
        }

        public CombinedGuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CombinedGuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
