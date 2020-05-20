using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class GuardedTaskExtensions
    {
        public static Task<T> AsSubjectTask<T>(this Task<Guarded<T>> guardedTask) 
            => guardedTask.ContinueWith(gt => gt.Result.Subject);
    }
}
