using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using B6.Core;
using Qweex.Monads.Either.Type;
using Roslyner.Domain.ClassForInject;

namespace Roslyner.Domain
{

    public class InjectedClassResult : TEither<CompileError, Customer>.P<InjectedClassResult>
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