using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class NotNullGuardFailedException : GuardFailedException
    {
        public NotNullGuardFailedException()
        {
        }

        public NotNullGuardFailedException(string message) : base(message)
        {
        }

        public NotNullGuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotNullGuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
