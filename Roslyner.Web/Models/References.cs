using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roslyner.Web.Models
{
    public class References : IEnumerable<MetadataReference>
    {
        private readonly string[] _paths;

        public References(params string[] paths)
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
            throw new NotImplementedException();
        }
    }
}
