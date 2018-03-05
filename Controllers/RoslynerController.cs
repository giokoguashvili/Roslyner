using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslyner.Models;

namespace Roslyner.Controllers
{
    public class RoslynerController : Controller
    {
        public IActionResult Index() 
        {
var tree = CSharpSyntaxTree.ParseText(@"
using System;
using Roslyner.Models;

namespace Roslyner.Test
{
    public class Foo : IFoo
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Method()
        {
            //Console.WriteLine(""Hello from Foo"");
            return 27;
        }
        public void Method1()
        {
        }
    }
}");
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Program).Assembly.Location)
            };
            var compiled = CSharpCompilation.Create(
                    "Foo",
                    new[] { tree },
                    references: references,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
             );

            using (var dll = new MemoryStream())
            {
                compiled.Emit(dll);
                var assembly = Assembly.Load(
                            dll.ToArray()
                        );

                var type = assembly.GetType("Roslyner.Test.Foo");
                var obj = (IFoo)Activator.CreateInstance(type);
                return View(obj.Sum(27, 14));   
            }
        }
    }
}