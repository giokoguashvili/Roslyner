using System;
using System.Collections.Generic;
using System.Linq;

namespace Roslyner.Domain.ClassForInject
{
    public abstract class CodeTemplateForInterface<T>
    {
        private readonly Usings _usings;
        private readonly string _namespace;
        private readonly string _className;

        protected CodeTemplateForInterface(string className, string @namespace, params Type[] classesForDependencies)
            : this(className, @namespace, new Usings(classesForDependencies.Concat(new List<Type>() { typeof(T) }).ToArray())) { }

        protected CodeTemplateForInterface(string className, string @namespace, Usings usings)
        {
            _className = className;
            _usings = usings;
            _namespace = @namespace;
        }

        public string Namespace()
        {
            return _namespace;
        }

        public IEnumerable<string> RequiredReferencesPaths()
        {
            return _usings.ReferencePaths();
        }

        public string NameWithNamespace()
        {
            return $"{_namespace}.{_className}";
        }

        public string Template()
        {
            return
                $@"using System;
{_usings}

namespace {_namespace}
{{
    public class {_className} : {typeof(T).Name}
    {{
        public string Check(int a, int b)
        {{
            return ""2 * (a + b)"";
        }}
    }}
}}";
        }
    }
}