using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGuards
{
    /// <summary>
    /// Represents a guard that decorates other guards to extend their behaviors
    /// </summary>
    /// <typeparam name="TGuard">type of the guard being decorated <see cref="IGuard{T}"/></typeparam>
    /// <typeparam name="T">Type of the subject of the guard being decorated</typeparam>
    public interface IGuardDecorator<TGuard, T> : IGuard<T> where TGuard : IGuard<T>
    {
    }
}
