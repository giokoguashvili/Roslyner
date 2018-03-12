using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Roslyner.Domain
{
    public class ClassInstance<T> : IClassInstance<T>
    {
        private readonly Lazy<Assembly> _assembly;
        private readonly string _namespace;

        public ClassInstance(IEnumerable<byte> compiledCode, string @namespace)
        {
            _assembly = new Lazy<Assembly>(() => Assembly.Load(compiledCode.ToArray()));
            this._namespace = @namespace;
        }

        public T Instance()
        {
            var type = _assembly.Value.GetType(_namespace);
            return (T)Activator.CreateInstance(type);
        }
    }
}