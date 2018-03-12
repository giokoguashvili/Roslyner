using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roslyner.Web.Controllers
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
