using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal interface IArrayFilterer
    {
        string Message { get; }
        IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens);
    }
}
