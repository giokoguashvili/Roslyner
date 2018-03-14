using B6.Core;
using Newtonsoft.Json;
using Roslyner.Domain;

namespace Roslyner.Web.Models
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