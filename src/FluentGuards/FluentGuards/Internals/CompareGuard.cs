using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    internal class CompareGuard<T> : GuardBase<T>, ICompareGuard<T> where T : IComparable<T>
    {
        private readonly T target;

        public CompareGuard(T subject, T target, CompareGuardTypes type) : base(subject)
        {
            this.target = target;
            CompareType = type;
        }

        public CompareGuardTypes CompareType { get; }

        public override Exception GetGuardException() => this.GetCompareException();

        public override Guarded<T> TryGuard()
        {
            if (Subject.IsMatch(target, CompareType))
            {
                return Subject;
            }

            return false;
        }
    }

    internal class AsyncCompareGuard<T> : AsyncGuardBase<T>, IAsyncCompareGuard<T> where T : IComparable<T>
    {
        private readonly T target;

        public AsyncCompareGuard(Task<T> subject, T target, CompareGuardTypes type) : base(subject)
        {
            this.target = target;
            CompareType = type;
        }

        public CompareGuardTypes CompareType { get; }

        public override Exception GetGuardException() => this.GetCompareException();

        public async override Task<Guarded<T>> TryGuardAsync()
        {
            var value = await Subject;
            if (value.IsMatch(target, CompareType))
            {
                return value;
            }

            return false;
        }
    }
}
