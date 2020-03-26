using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal class StringTokenValueValidator : IStringTokenValueValidator
    {
        public TokenName TokenName => TokenName.String;

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.TakeToken();
            if (value is null || value.Name != TokenName.String)
            {
                var error = new ParserError("Value is supposed to be string.", value.Line, value.Column);
                return new[] { ValidationResult.Error(error) };
            }
            return new[] { ValidationResult.Success() };
        }
    }
}
