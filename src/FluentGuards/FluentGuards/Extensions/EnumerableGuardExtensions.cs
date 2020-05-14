using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class EnumerableGuardExtensions
    {
        public static IGuard<IEnumerable<T>> NotEmpty<T>(this IEnumerable<T> subject) => new SimpleGuard<IEnumerable<T>>(subject, s => s != null && s.Any(), new ArgumentNullException("subject", "Subject cannot be null or empty"));
        public static IAsyncGuard<IEnumerable<T>> NotEmpty<T>(this Task<IEnumerable<T>> subject) => new AsyncSimpleGuard<IEnumerable<T>>(subject, s => s != null && s.Any(), new ArgumentNullException("subject", "Subject cannot be null or empty"));
    }
}
