using System;

namespace Roslyner.Domain.Infrastructure
{
    public interface IMonad<M0, out T0, T1>
        where M0 : IMonad<M0, T0, T1>
    {
        M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
            where M1 : IMonad<M1, T2, T1>
            where T2 : class;
    }
}