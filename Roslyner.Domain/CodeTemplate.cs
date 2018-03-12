namespace Roslyner.Domain
{
    public class CodeTemplateForInterface<T>
    {
        private readonly string _interfaceNamespace;
        private readonly string _namespace = "FooNamespace";
        private readonly string _className = "Foo";
        public CodeTemplateForInterface(string interfaceNamespace)
        {
            _interfaceNamespace = interfaceNamespace;
        }
        public CodeTemplateForInterface() : this(typeof(T).Namespace) { }

        public string Namespace()
        {
            return _namespace;
        }

        public string NameWithNamespace()
        {
            return $"{_namespace}.{_className}";
        }

        public string Template()
        {
            return
                $@"using System;
using {_interfaceNamespace};

namespace {_namespace}
{{
    public class {_className} : IFoo
    {{
        public int Sum(int a, int b)
        {{
            return 2 * (a + b);
        }}
    }}
}}";
        }
    }
}