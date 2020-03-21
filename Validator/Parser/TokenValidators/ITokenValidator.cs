using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal interface ITokenValidator
    {
        TokenName TokenName { get; }
        ValidationResult Validate(Token token, ITokenCollection tokenCollection);
    }
}
