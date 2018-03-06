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
        public JsonResult Build([FromBody] MonacoEditorModel model)
        {
            using (var dll = new MemoryStream())
            {
                CSharpCompilation.Create(
                    "Foo",
                    new[] { CSharpSyntaxTree.ParseText(model.Code) },
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