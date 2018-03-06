using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Roslyner.Web.Models
{
    public class InjectedObject : IFoo
    {
        private readonly Lazy<Assembly> assembly;
        private readonly string _Namespace;

        public InjectedObject(IEnumerable<byte> compiledCode, string _namespace)
        {
            assembly = new Lazy<Assembly>(() => Assembly.Load(compiledCode.ToArray()));
            _Namespace = _namespace;
        }
        public int Sum(int a, int b)
        {
            var type = assembly.Value.GetType(_Namespace);
            var obj = (IFoo)Activator.CreateInstance(type);
            return obj.Sum(a, b);
        }
    }
}
