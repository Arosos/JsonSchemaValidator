using System.Collections.Generic;
using System.Linq;

namespace JsonSchemaValidator.Validator.Parser
{
    public class ParserResult
    {
        public IReadOnlyCollection<ParserError> ParserErrors { get; }

        public ParserResult(IEnumerable<ParserError> parserErrors)
        {
            ParserErrors = parserErrors.ToList();
        }
    }
}
