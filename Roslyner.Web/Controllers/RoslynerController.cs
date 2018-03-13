using System;
using System.IO;
using System.Linq;
using B6.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            try
            {
                return Json(
                    new BuildResult(
                        JsonConvert
                            .SerializeObject(
                                new InjectedClassCodeInstance<IRule>(
                                    model.Code,
                                    new CodeTemplateForFooClass()
                                )
                                .Instance()
                                .Check()
                            )
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