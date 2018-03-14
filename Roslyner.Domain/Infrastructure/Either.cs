using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Union
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
            var a = this
                     .Match(
                         (r) => m(r),
                         (e) => new M1().Return(e)
                     );
            return (M1)a;
            //throw new Exception();
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

    //public interface IKindTwo<T1, T2>
    //{
    //    IKindTwo<T1, T2> Return<T4, T5>(IKi);
    //}

    //public interface IMonad<T1, T2>
    //{
    //    TResult Bind<TResult>(Func<T1, TResult> func);
    //}

    //public class Monad<T1, T2> : IMonad<T1, T2>
    //    where T1 : class
    //    where T2 : class
    //{
    //    private readonly Union<T1, T2> _box;

    //    public Monad(Union<T1, T2> box)
    //    {
    //        _box = box;
    //    }
    //    public TResult Bind<TResult>(Func<T1, TResult> func)
    //        where TResult : IKindTwo<TResult>
    //    {
    //        return _box
    //            .Match(
    //                (l) => func(l),
    //                (e) => new TResult().Return(e)
    //            );
    //    }
    //}
}
