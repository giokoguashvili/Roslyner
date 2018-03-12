using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Roslyner.Domain
{
    public class References : IEnumerable<MetadataReference>
    {
        private readonly IEnumerable<string>_paths;

        public References(IEnumerable<string> paths)
        {
            _paths = paths;
        }
        public IEnumerator<MetadataReference> GetEnumerator()
        {
            return _paths
                .Select(path => MetadataReference.CreateFromFile(path))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
