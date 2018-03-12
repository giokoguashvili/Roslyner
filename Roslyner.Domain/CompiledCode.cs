using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Roslyner.Domain
{
    public class CompiledCode : IEnumerable<byte>
    {
        private readonly string _assemblyName;
        private readonly IEnumerable<MetadataReference> _references;
        private readonly string _code;

        public CompiledCode(string code, IEnumerable<MetadataReference> references) : this(code, references, "InjectedCodeAssembly") {}
        public CompiledCode(string code, IEnumerable<MetadataReference> references, string assemblyName)
        {
            _assemblyName = assemblyName;
            _references = references;
            _code = code;
        }

        public IEnumerator<byte> GetEnumerator()
        {
            using (var dll = new MemoryStream())
            {
                CSharpCompilation.Create(
                    _assemblyName,
                    new[] { CSharpSyntaxTree.ParseText(_code) },
                    _references,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                ).Emit(dll);
                return dll
                    .ToArray()
                    .ToList()
                    .GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}