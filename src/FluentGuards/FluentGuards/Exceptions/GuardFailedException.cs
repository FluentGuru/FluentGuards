using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentGuards
{
    public class GuardFailedException : Exception
    {
        public GuardFailedException()
        {
        }

        public GuardFailedException(string message) : base(message)
        {
        }

        public GuardFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GuardFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
