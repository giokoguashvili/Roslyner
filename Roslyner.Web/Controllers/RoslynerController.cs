using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslyner.Web.Models;

namespace Roslyner.Web.Controllers
{
    public class RoslynerController : Controller
    {
        [HttpPost]
        public JsonResult Build(string code)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
using System;
using Roslyner.Web.Models;

namespace Roslyner.Test
{
    public class Foo : IFoo
    {
        public int Sum(int a, int b)
        {
            return 2 * (a + b);
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
            using (var dll = new MemoryStream())
            {
                CSharpCompilation.Create(
                    "Foo",
                    new[] { tree },
                    references: new MetadataReference[]
                    {
                        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(Program).Assembly.Location)
                    },
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                ).Emit(dll);
                var assembly = Assembly.Load(
                            dll.ToArray()
                        );

                var type = assembly.GetType("Roslyner.Test.Foo");
                var obj = (IFoo)Activator.CreateInstance(type);
                return Json(new
                {
                    codeResult = obj.Sum(27, 14)
                });
            }
        
        }
    }
}