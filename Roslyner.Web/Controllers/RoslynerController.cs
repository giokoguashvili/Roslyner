using Microsoft.AspNetCore.Mvc;
using Roslyner.Domain;
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
                                new TypesAssemblyLocation(
                                    typeof(object),
                                    typeof(IFoo)
                                )
                            )
                        ),
                        @namespace: "Roslyner.Domain.Foo"
                    )
                    .Sum(27, 14)
                )
            );
        }
    }
}