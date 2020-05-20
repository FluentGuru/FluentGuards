using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class GuardedTaskExtensions
    {
        /// <summary>
        /// Returns a Task that returns the subject of the guarded result
        /// </summary>
        /// <typeparam name="T">type of the guarded subject</typeparam>
        /// <param name="guardedTask">the task that returns the guarded result</param>
        /// <returns>a task that returns the subject guarded</returns>
        public static Task<T> AsSubjectTask<T>(this Task<Guarded<T>> guardedTask) 
            => guardedTask.ContinueWith(gt => gt.Result.Subject);
    }
}
