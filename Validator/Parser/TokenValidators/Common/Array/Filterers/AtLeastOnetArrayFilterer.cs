using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal class AtLeastOnetArrayFilterer : IArrayFilterer
    {
        public string Message => "Array was supposed to contain at least one element.";

        public IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens)
        {
            if (!tokens.Any())
                throw new EmptyArrayException();
            return new Token[] { };
        }
    }
}
