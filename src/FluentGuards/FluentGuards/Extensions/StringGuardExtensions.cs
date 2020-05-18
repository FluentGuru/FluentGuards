using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class StringGuardExtensions
    {
        public static IGuard<string> NotEmpty(this string subject) => new SimpleGuard<string>(subject, s => !string.IsNullOrEmpty(s), new NotEmptyGuardFailedException("Subject cannot be null or empty"));

        public static IAsyncGuard<string> NotEmpty(this Task<string> subject) => new AsyncSimpleGuard<string>(subject, s => !string.IsNullOrEmpty(s), new NotEmptyGuardFailedException("Subject cannot be null or empty"));
    }
}
