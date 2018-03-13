using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Roslyner.Domain
{
    public class References : IEnumerable<MetadataReference>
    {
        private readonly IEnumerable<Type> _types;

        public References(IEnumerable<Type> types)
        {
            _types = types;
        }
        public IEnumerator<MetadataReference> GetEnumerator()
        {
            return _types
                    .Select(t => t.Assembly.Location)
                    .Distinct()
                    .Select(path => MetadataReference.CreateFromFile(path))
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
