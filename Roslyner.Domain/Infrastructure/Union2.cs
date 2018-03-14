using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Union
{
    public class Union<T1, T2> 
           where T1 : class
           where T2 : class
    {
        private readonly T1 _t1;
        private readonly T2 _t2;
        private readonly Func<Union<T1, T2>> _factory;
        private object v;

        public Union(T1 t1) { _t1 = t1; }
        public Union(T2 t2) { _t2 = t2; }
        public Union(Func<Union<T1, T2>> factory)
        {
            _factory = factory;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> f1,
            Func<T2, TResult> f2
        )
        {
            if (_factory != null)
            {
                return _factory()
                    .Match(f1, f2);
            }
            else if (_t1 != null)
            {
                return f1(_t1);
            }
            else if (_t2 != null)
            {
                return f2(_t2);
            }
            throw new Exception("can't match");
        }
        public interface IMatcher<TResult>
        {
            TResult F1(T1 t);
            TResult F2(T2 t);

        }
        public TResult Match<TResult>(
            IMatcher<TResult> matcher
        )
        {
            return this.Match((a) => matcher.F1(a), (e) => matcher.F2(e));
        }

        //public object Content()
        //{
        //    if (_t1 != null)
        //    {
        //        return _t1;
        //    }
        //    return _t2;
        //}
    }
}
