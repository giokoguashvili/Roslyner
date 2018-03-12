using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyner.Domain
{
    public interface IClassInstance<out T>
    {
        T Instance();
    }
}
