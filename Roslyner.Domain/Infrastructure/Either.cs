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
}
