using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class SimpleGuard<T> : GuardBase<T>
    {
        private readonly Func<T, bool> predicate;
        private readonly Exception exception;

        public SimpleGuard(T subject, Func<T, bool> predicate, Exception exception) : base(subject)
        {
            this.predicate = predicate;
            this.exception = exception;
        }

        public override Exception GetGuardException() => exception;

        public override Guarded<T> TryGuard()
        {
            var guarded = predicate(Subject);
            if(guarded)
            {
                return Subject;
            }

            return guarded;
        }
    }

    internal class AsyncSimpleGuard<T> : AsyncGuardBase<T>
    {
        private readonly Func<T, bool> predicate;
        private readonly Exception exception;
        
        public AsyncSimpleGuard(Task<T> subject, Func<T, bool> predicate, Exception exception) : base(subject)
        {
            this.predicate = predicate;
            this.exception = exception;
        }

        public override Exception GetGuardException() => exception;

        public async override Task<Guarded<T>> TryGuardAsync()
        {
            var result = await Subject;
            var guarded = predicate(result);
            if(guarded)
            {
                return result;
            }

            return guarded;
        }
    }
}
