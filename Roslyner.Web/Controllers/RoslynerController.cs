using Microsoft.AspNetCore.Mvc;
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
                        new CompiledCode(
                            model.Code, 
                            new References(
                                typeof(object).Assembly.Location,
                                typeof(Program).Assembly.Location
                            ),
                            assemblyName: "Foo"
                        ),
                        @namespace: "Roslyner.Test.Foo"
                    )
                    .Sum(27, 14)
                )
            );
        }
    }
}