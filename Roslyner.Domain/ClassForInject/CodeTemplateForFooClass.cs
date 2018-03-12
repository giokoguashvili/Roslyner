using B6.Core;

namespace Roslyner.Domain.ClassForInject
{
    public class CodeTemplateForFooClass : CodeTemplateForInterface<IFoo>
    {
        public CodeTemplateForFooClass() : base(
                "Foo",
                "FooNamespace",
                typeof(UserUtils)
            )
        {}
    }
}
