using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Roslyner.Domain.ClassForInject
{

    public class Dependencies
    {
        private readonly Usings _usings;
        private readonly References _references;

        public Dependencies(params Type[] types)
            : this(
                  new Usings(types), 
                  new References(types)
              )
        { }
        public Dependencies(Usings usings, References references)
        {
            _usings = usings;
            _references = references;
        }
        public Usings Usings()
        {
            return _usings;
        }
        public References References()
        {
            return _references;
        }
    }

    public abstract class CodeTemplateForInterface<T>
    {
        private readonly string _namespace;
        private readonly Dependencies _dependencies;
        private readonly string _className;

        protected CodeTemplateForInterface(string className, string @namespace, Dependencies dependencies)
        {
            _className = className;
            _namespace = @namespace;
            _dependencies = dependencies;
        }

        public Dependencies Dependencies()
        {
            return _dependencies;
        }

        public string NameWithNamespace()
        {
            return $"{_namespace}.{_className}";
        }

        public string Template()
        {
            return
                $@"using System;
{_dependencies.Usings()}

namespace {_namespace}
{{
    public class {_className} : {typeof(T).Name}
    {{
        public Customer Check()
        {{
            return UserUtils.GetCustomer();
        }}
    }}
}}";
        }
    }
}