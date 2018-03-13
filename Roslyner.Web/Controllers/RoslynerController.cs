using System;
using System.IO;
using System.Linq;
using B6.Core;
using Microsoft.AspNetCore.Mvc;
using Roslyner.Domain;
using Roslyner.Domain.ClassForInject;
using Roslyner.Domain.Interfaces;
using Roslyner.Web.Models;

namespace Roslyner.Web.Controllers
{
    public class RoslynerController : Controller
    {
        [HttpPost]
        public JsonResult Build([FromBody] MonacoEditorModel model)
        {
            //new CompiledCode(
            //    model.Code,
            //    new References(
            //        new TypesAssemblyLocation(
            //                typeof(object)
            //            )
            //            .Concat(new CodeTemplateForFooClass().RequiredReferencesPaths())
            //            .Distinct()
            //    )
            //);

            try
            {
                return Json(
                    new BuildResult(
                        new InjectedClassCodeInstance<IFoo>(
                                model.Code,
                                new CodeTemplateForFooClass()
                            )
                            .Instance()
                            .Check(27, 14)
                    )
                );
            }
            catch (Exception e)
            {
                return Json(new BuildResult(e.Message));
            }
            
        }
    }
}