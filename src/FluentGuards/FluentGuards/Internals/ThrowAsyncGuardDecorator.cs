namespace FluentGuards.Internals
{
    internal class ThrowAsyncGuardDecorator<TGuard, T> : AsyncGuardDecoratorBase<TGuard, T>, IAsyncGuard<T> where TGuard : IAsyncGuard<T>
}
