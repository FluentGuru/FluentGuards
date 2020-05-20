using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// Exception throw by not null guard failures
    /// </summary>
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
