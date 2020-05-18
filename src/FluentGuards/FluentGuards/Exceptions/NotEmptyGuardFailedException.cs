using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class NotEmptyGuardFailedException : GuardFailedException
    {
        public NotEmptyGuardFailedException()
        {
        }

        public NotEmptyGuardFailedException(string message) : base(message)
        {
        }

        public NotEmptyGuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEmptyGuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
