using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class StringGuardExtensions
    {
        public static IGuard<string> NotEmpty(this string subject) => subject.Guard(s => !string.IsNullOrEmpty(s), new NotEmptyGuardFailedException("Subject cannot be null or empty"));

        public static IAsyncGuard<string> NotEmpty(this Task<string> subject) => subject.GuardAsync(s => !string.IsNullOrEmpty(s), new NotEmptyGuardFailedException("Subject cannot be null or empty"));
    }
}
