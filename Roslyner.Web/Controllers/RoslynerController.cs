using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using B6.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qweex.Monads.Either;
using Qweex.Monads.Either.Type;
using Qweex.Unions;
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
                        .Match(
                            e => new BuildResult(e.Message),
                            r => new BuildResult(
                                    JsonConvert.SerializeObject(r)
                                )
                         )
                    );

            return new CompiledCode(
                model.Code,
                new CodeTemplateForFooClass()
            ).Bind((a) => new Either<CompileError, Customer>(
                            new InjectedClassCodeInstance<IRule>(
                                    a,
                                    new CodeTemplateForFooClass()
                                )
                                .Instance()
                                .Check()
                            )
            )
            .Match(
                (error) => Json(new BuildResult(error.Message)),
                (compiledCode) => Json(
                    new BuildResult(
                        JsonConvert
                            .SerializeObject(compiledCode)
                    )
                )
            );

            return new CompiledCode(
                        model.Code,
                        new CodeTemplateForFooClass()
                    ).Match(
                        (error) => Json(new BuildResult(error.Message)),
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
                                        )
                    );
        }
    }
}