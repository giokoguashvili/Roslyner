namespace Roslyner.Web.Models
{

    public class BuildResult
    {
        public BuildResult(string codeResult)
        {
            CodeResult = codeResult;
        }
        public BuildResult(int methodResult) : this(methodResult.ToString()) { }
       
        public string CodeResult { get; }
    }
}