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
            return Json(
                new BuildResult(
                    new InjectedObject(
                        new CompiledCode(model.Code),
                        "Roslyner.Test.Foo"
                    )
                    .Sum(27, 14)
                    .ToString()
                )
            );
        }
    }
}