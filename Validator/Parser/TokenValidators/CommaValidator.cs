using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class CommaValidator : ITokenValidator
    {
        public TokenName TokenName => TokenName.Comma;

        public ValidationResult Validate(Token token, ITokenCollection tokenCollection)
        {
            return ValidationResult.Success();
        }
    }
}
