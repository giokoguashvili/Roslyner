using System;
using System.Collections.Generic;
using System.Linq;

namespace Roslyner.Domain
{
    public class Usings
    {
        private readonly Type[] _classesForDependencies;

        public Usings(Type[] classesForDependencies)
        {
            _classesForDependencies = classesForDependencies;
        }

        public IEnumerable<string> ReferencePaths()
        {
            return _classesForDependencies
                .Select(t => t.Assembly.Location)
                .Distinct();
        }

        public override string ToString()
        {
            return String
                .Join(
                    Environment.NewLine,
                    _classesForDependencies
                        .Select(type => $"using {type.Namespace};")
                        .Distinct()
                );
        }
    }
}