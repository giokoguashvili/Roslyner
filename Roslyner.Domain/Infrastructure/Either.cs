using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Union
{
    public class Either<TLeft, TRight> : Union<TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public Either(Func<Either<TLeft, TRight>> factory) : base(factory) { }
        public Either(TLeft t1) : base(t1)
        {
        }

        public Either(TRight t2) : base(t2)
        {
        }
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
