using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal class IntegerTokenValueValidator : IIntegerTokenValueValidator
    {
        public TokenName TokenName => TokenName.Number;

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.TakeToken();
            if (value is null || value.Name != TokenName.Number)
            {
                var error = new ParserError($"{token.Name} should be numer", token.Line, token.Column);
                return new[] { ValidationResult.Error(error) };
            }

            return new[] { ValidationResult.Success() };
        }
    }
}
