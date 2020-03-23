using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class IdValidator : ITokenValidator
    {
        public TokenName TokenName => new TokenName(new IdKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var valueToken = tokenCollection.TakeToken();
            if (valueToken is null || valueToken.Name != TokenName.String || !valueToken.Value.Any() || Fragment.Empty.Value == valueToken.Value)
            {
                var parserError = new ParserError("Id value is supposed to be string and cannot be empty", valueToken.Line, valueToken.Column);
                return new[] { ValidationResult.Error(parserError) };
            }
            return new[] { ValidationResult.Success() };
        }
    }
}
