using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal class SingleArrayFilterer : IArrayFilterer
    {
        public string Message => "Array was supposed to contain at least one element.";

        public IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens)
        {
            var result = tokens
                .Skip(1)
                .ToList();
            return result;
        }
    }
}
