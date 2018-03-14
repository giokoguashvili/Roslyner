using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            return Json(
                        new CompiledCode(
                            model.Code,
                            new CodeTemplateForFooClass()
                        )
                        .Bind((a) => new InjectedClassResult(a))
                        .Match(new InjectedClassResutMatcher())
                    );

            return new CompiledCode(
                        model.Code,
                        new CodeTemplateForFooClass()
                    ).Match(
                        (compiledCode) => Json(
                                            new BuildResult(
                                                JsonConvert
                                                    .SerializeObject(
                                                        new InjectedClassCodeInstance<IRule>(
                                                            compiledCode,
                                                            new CodeTemplateForFooClass()
                                                        )
                                                        .Instance()
                                                        .Check()
                                                    )
                                            )
                                        ),
                        (error) => Json(new BuildResult(error.Message))
                    );
        }
    }
}