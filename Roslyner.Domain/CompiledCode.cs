using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using B6.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Qweex.Monads.Either.Type;
using Roslyner.Domain.ClassForInject;

namespace Roslyner.Domain
{
    public class CompiledCode : TEither<CompileError, IEnumerable<byte>>.P<CompiledCode>
    {
        public CompiledCode(string code, CodeTemplateForFooClass template) : this(code, template, "InjectedCodeAssembly") { }
        public CompiledCode(string code, CodeTemplateForFooClass template, string assemblyName) : base(() =>
        {
            using (var dll = new MemoryStream())
            {
                var emitResult = CSharpCompilation.Create(
                    assemblyName,
                    new[] { CSharpSyntaxTree.ParseText(code) },
                    template.Dependencies().References(),
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                ).Emit(dll);

                if (!emitResult.Success)
                {
                    return new CompiledCode(
                                new CompileError(
                                    String
                                        .Join(
                                            Environment.NewLine,
                                            emitResult
                                                .Diagnostics
                                                .Select(d => d.GetMessage())
                                        )
                                )
                           );
                }

                return new CompiledCode(
                            dll
                                .ToArray()
                                .ToList()
                    );
            }
        }) {}

        public CompiledCode(IEnumerable<byte> t1) : base(t1) {}
        public CompiledCode(CompileError t2) : base(t2) {}
    }
}