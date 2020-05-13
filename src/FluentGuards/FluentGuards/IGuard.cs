using System;

namespace FluentGuards
{
    public interface IGuard<T>
    {
        T Guard();
        Guarded<T> TryGuard();
        Exception GetGuardException();
    }
}
