using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Roslyner.Domain.ClassForInject
{
    public class Dependencies
    {
        private readonly Usings _usings;
        private readonly References _references;

        public Dependencies(params Type[] types)
            : this(
                  new Usings(types), 
                  new References(types)
              )
        { }
        public Dependencies(Usings usings, References references)
        {
            _usings = usings;
            _references = references;
        }
        public Usings Usings()
        {
            return _usings;
        }
        public References References()
        {
            return _references;
        }
    }
}