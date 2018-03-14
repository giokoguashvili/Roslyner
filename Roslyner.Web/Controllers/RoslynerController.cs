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
using Types.Union;

namespace Roslyner.Web.Controllers
{
    public class InjectedClassResut : Either<Customer, CompileError>
    {
        public InjectedClassResut(IEnumerable<byte> compiledCode) : base(() =>
        {
            return new InjectedClassResut(
                new InjectedClassCodeInstance<IRule>(
                                        compiledCode,
                                        new CodeTemplateForFooClass()
                                    )
                                    .Instance()
                                    .Check());
        }) { }
        public InjectedClassResut(Customer t1) : base(t1)
        {
        }

        public InjectedClassResut(CompileError t2) : base(t2)
        {
        }

    }

    public class Mattcher
    {

    }
    public class RoslynerController : Controller
    {
        [HttpPost]
        public JsonResult Build([FromBody] MonacoEditorModel model)
        {

            return new CompiledCode(
                        model.Code,
                        new CodeTemplateForFooClass()
                    )
                    .Bind((a) => new InjectedClassResut(a))
                    .Match(
                        (compiledCode) => Json(
                                                new BuildResult(
                                                    JsonConvert
                                                        .SerializeObject(
                                                            compiledCode
                                                        )
                                                )
                                            ),
                        (error) => Json(new BuildResult(error.Message))
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
            //return new CompiledCode(
            //            model.Code,
            //            new CodeTemplateForFooClass()
            //        ).Match(
            //            (compiledCode) => Json(
            //                                new BuildResult(
            //                                    JsonConvert
            //                                        .SerializeObject(
            //                                            new InjectedClassCodeInstance<IRule>(
            //                                                compiledCode,
            //                                                new CodeTemplateForFooClass()
            //                                            )
            //                                            .Instance()
            //                                            .Check()
            //                                        )
            //                                )
            //                            ),
            //            (error) => Json(new BuildResult(error.Message))
            //        );
        }
    }
}