using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyner.Domain.Infrastructure
{
    public abstract class Factory<TMonad>
    {
        private readonly Func<TMonad> _factory;

        protected Factory(Func<TMonad> factory)
        {
            _factory = factory;
        }
    }
}
