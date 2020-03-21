using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal interface IElementExtractor
    {
        IReadOnlyCollection<Token> GetElementTokens(ITokenCollection tokenCollection);
    }
}