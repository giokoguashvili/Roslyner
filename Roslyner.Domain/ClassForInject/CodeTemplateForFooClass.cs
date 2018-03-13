using B6.Core;
using System.IO;
using System.Net;

namespace Roslyner.Domain.ClassForInject
{
    public class CodeTemplateForFooClass : CodeTemplateForInterface<IRule>
    {
        public CodeTemplateForFooClass() : base(
                "Foo",
                "FooNamespace",
                new Dependencies(
                    typeof(object),
                    typeof(IRule),
                    typeof(FileAttributes),
                    typeof(WebClient),
                    typeof(UserUtils)
                )
            )
        {}
    }


}
