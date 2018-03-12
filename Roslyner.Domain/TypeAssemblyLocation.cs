using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Roslyner.Domain
{ 
    public class TypesAssemblyLocation : IEnumerable<string>
    {
        private readonly Type[] _types;

        public TypesAssemblyLocation(params Type[] types)
        {
            _types = types;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _types
                     .Select(type => type.Assembly.Location)
                     .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
