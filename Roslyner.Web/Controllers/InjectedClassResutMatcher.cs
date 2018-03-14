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

    public class InjectedClassResutMatcher : InjectedClassResult.IMatcher<BuildResult>
    {
        public BuildResult F1(Customer t)
        {
            return new BuildResult(
                        JsonConvert.SerializeObject(t)
                    );
        }
        public BuildResult F2(CompileError t)
        {
            return new BuildResult(t.Message);
        }
    }
}