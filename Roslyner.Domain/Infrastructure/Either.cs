using System;

namespace Roslyner.Domain.Infrastructure
{
    public class Either<TLeft, TRight> : Union<TLeft, TRight>,
        IMonad<Either<TLeft, TRight>, TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public Either() : base((TRight)null)
        {

        }
        public Either(Func<Either<TLeft, TRight>> factory) : base(factory) { }
        public Either(TLeft t1) : base(t1)
        {
        }

        public Either(TRight t2) : base(t2)
        {
        }

        public M1 Bind<M1, T2>(Func<TLeft, IMonad<M1, T2, TRight>> m)
            where M1 : IMonad<M1, T2, TRight>, new ()
        {
            return (M1)Match(m, (e) => new M1().Return(e));
        }

        public Either<TLeft, TRight> Return(TLeft t)
        {
            return new Either<TLeft, TRight>(t);
        }

        public Either<TLeft, TRight> Return(TRight t)
        {
            return new Either<TLeft, TRight>(t);
        }
    }


    public interface IMonad<M0, T0, T1>
        where M0 : IMonad<M0, T0, T1>, new ()
    {
        M0 Return(T0 t);
        M0 Return(T1 t);

        M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
            where M1 : IMonad<M1, T2, T1>, new ();
    }
}
