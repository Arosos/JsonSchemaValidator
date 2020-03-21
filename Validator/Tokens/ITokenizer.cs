using System.Collections.Generic;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal interface ITokenizer
    {
        IEnumerable<Token> GetTokens(string input);
    }
}
