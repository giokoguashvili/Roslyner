using Roslyner.Domain;

namespace Roslyner.Web.Models
{
    public class CodeTemplateResult<T>
    {
        private readonly CodeTemplateForInterface<T> _codeTemplateForInterface;

        public CodeTemplateResult(CodeTemplateForInterface<T> codeTemplateForInterface)
        {
            _codeTemplateForInterface = codeTemplateForInterface;
        }

        public string Template => _codeTemplateForInterface.Template();
    }
}