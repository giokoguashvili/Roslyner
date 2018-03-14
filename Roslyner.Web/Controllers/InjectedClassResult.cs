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
    public class InjectedClassResult : Either<Customer, CompileError>
    {
        public InjectedClassResult(IEnumerable<byte> compiledCode) : base(() =>
        {
            return new InjectedClassResult(
                new InjectedClassCodeInstance<IRule>(
                                        compiledCode,
                                        new CodeTemplateForFooClass()
                                    )
                                    .Instance()
                                    .Check());
        }) {}
        public InjectedClassResult(Customer t1) : base(t1)
        {
        }

        public InjectedClassResult(CompileError t2) : base(t2)
        {
        }
    }
}