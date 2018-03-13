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