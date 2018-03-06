using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roslyner.Web.Models
{
    public class BuildResult
    {
        public BuildResult(string codeResult)
        {
            CodeResult = codeResult;
        }

        public string CodeResult { get; }
    }
}
