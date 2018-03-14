using System;

namespace Roslyner.Domain.Infrastructure
{
    public class Either<TLeft, TRight> : Union<TLeft, TRight>,
        IMonad<Either<TLeft, TRight>, TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public Either(Func<Either<TLeft, TRight>> factory) : base(factory) { }
        public Either(TLeft t1) : base(t1) {}
        public Either(TRight t2) : base(t2) {}

        public M1 Bind<M1, T2>(Func<TLeft, IMonad<M1, T2, TRight>> m)
            where M1 : IMonad<M1, T2, TRight>
            where T2 : class
        {
            return (M1)Match(m, (e) => (IMonad<M1, T2, TRight>)new Either<T2, TRight>(e));
        }
    }
}
