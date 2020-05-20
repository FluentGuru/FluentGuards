using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class CompareGuardFailedException : GuardFailedException
    {
        public CompareGuardFailedException()
        {
        }

        public CompareGuardFailedException(string message) : base(message)
        {
        }

        public CompareGuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompareGuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
