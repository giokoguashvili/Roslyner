using System.Collections.Generic;
using B6.Core;
using Roslyner.Domain.ClassForInject;
using Roslyner.Domain.Infrastructure;

namespace Roslyner.Domain
{
    public class InjectedClassResult : Either<Customer, CompileError>
    {
        public InjectedClassResult(IEnumerable<byte> compiledCode) : base(() =>
        {
            return new InjectedClassResult(
                        new InjectedClassCodeInstance<IRule>(
                                                compiledCode,
                                                new CodeTemplateForFooClass()
                                            )
                                            .Instance()
                                            .Check()
                  );
        }) {}
        public InjectedClassResult(Customer t1) : base(t1)
        {
        }

        public InjectedClassResult(CompileError t2) : base(t2)
        {
        }
    }
}