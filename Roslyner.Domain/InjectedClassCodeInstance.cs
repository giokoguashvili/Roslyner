using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Roslyner.Domain.ClassForInject;
using Roslyner.Domain.Interfaces;

namespace Roslyner.Domain
{
    public class InjectedClassCodeInstance<T> : IClassInstance<T>
    {
        private readonly IClassInstance<T> _class;
        public InjectedClassCodeInstance(IEnumerable<byte> code, CodeTemplateForInterface<T> codeTemplate) 
            : this(
                    new ClassInstance<T>(
                        code,
                        codeTemplate.NameWithNamespace()
                    )
                  )
        {

        }

        public InjectedClassCodeInstance(IClassInstance<T> classInstance)
        {
            _class = classInstance;
        }

        public T Instance()
        {
            return _class.Instance();
        }
    }
}
