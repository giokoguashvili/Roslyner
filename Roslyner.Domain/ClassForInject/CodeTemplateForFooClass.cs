using B6.Core;

namespace Roslyner.Domain.ClassForInject
{
    public class CodeTemplateForFooClass : CodeTemplateForInterface<IRule>
    {
        public CodeTemplateForFooClass() : base(
                "Foo",
                "FooNamespace",
                typeof(UserUtils)
            )
        {}
    }
}
