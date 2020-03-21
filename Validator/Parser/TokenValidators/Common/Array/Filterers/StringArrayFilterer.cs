using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal class StringArrayFilterer : IArrayFilterer
    {
        public string Message => "All elements are supposed to be string.";

        public IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens)
        {
            var result = tokens
                .Where(element => element.Name != TokenName.String)
                .ToList();
            return result;
        }
    }
}
