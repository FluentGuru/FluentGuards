using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentGuards
{
    public static class ComparisonGuardExtensions
    {
        /// <summary>
        /// Builds a comparison guard for the subject
        /// </summary>
        /// <typeparam name="T">the type of the subject</typeparam>
        /// <param name="subject">the subject to guard</param>
        /// <param name="target">the target to compare againsts</param>
        /// <param name="compareType">the type of comparison to do against the target. See <see cref="CompareGuardTypes"/></param>
        /// <returns>an instance of <see cref="ICompareGuard{T}"/> that will guard the subject </returns>
        public static ICompareGuard<T> Compare<T>(this T subject, T target, CompareGuardTypes compareType) where T : IComparable<T>
            => new CompareGuard<T>(subject, target, compareType);

        /// <summary>
        /// builds an async comparison guard for the subject
        /// </summary>
        /// <typeparam name="T">result type of the subject task</typeparam>
        /// <param name="subject">The subject to guard/param>
        /// <param name="target">the target to compare against</param>
        /// <param name="compareType">the type of comparison to do against the target. See <see cref="CompareGuardTypes"/></param>
        /// <returns>an instance of <see cref="IAsyncCompareGuard{T}"/> that will guard the subject </returns>
        public static IAsyncCompareGuard<T> Compare<T>(this Task<T> subject, T target, CompareGuardTypes compareType) where T : IComparable<T>
            => new AsyncCompareGuard<T>(subject, target, compareType);

        /// <summary>
        /// Guards that the subject equals to the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> EqualsTo<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.Equals);

        /// <summary>
        /// Guards that the result of a task subject is equal to the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> EqualsTo<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.Equals);

        /// <summary>
        /// Guards that the subject is not equals to the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> NotEqualsTo<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.NotEquals);

        /// <summary>
        /// Guards that the result of a task subject is not equal to the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> NotEqualsTo<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.NotEquals);

        /// <summary>
        /// Guards that the result of a subject is greater than the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> GreaterThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterThan);

        /// <summary>
        /// Guards that the result of a task subject is greater than the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> GreaterThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterThan);

        /// <summary>
        /// Guards that the subject is less than the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> LessThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessThan);

        /// <summary>
        /// Guards that the result of the task subject is less than the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> LessThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessThan);

        /// <summary>
        /// Guards that the subject is greater or equal than the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> GreaterOrEqualThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterOrEqualThan);

        /// <summary>
        /// Guards that the result of the task subject is greater or equal than the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> GreaterOrEqualThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.GreaterOrEqualThan);

        /// <summary>
        /// Guards that the subject is less or equal than the target
        /// </summary>
        /// <see cref="Compare{T}(T, T, CompareGuardTypes)"/>
        public static ICompareGuard<T> LessOrEqualThan<T>(this T subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessOrEqualThan);

        /// <summary>
        /// Guards that the result of the subject task is less or equal than the target
        /// </summary>
        /// <see cref="Compare{T}(Task{T}, T, CompareGuardTypes)"/>
        public static IAsyncCompareGuard<T> LessOrEqualThan<T>(this Task<T> subject, T target) where T : IComparable<T>
            => subject.Compare(target, CompareGuardTypes.LessOrEqualThan);
    }
}
