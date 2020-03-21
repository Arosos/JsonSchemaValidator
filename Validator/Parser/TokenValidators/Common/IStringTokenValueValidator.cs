using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal interface IStringTokenValueValidator
    {
        ValidationResult Validate(Token token, ITokenCollection tokenCollection);
    }
}
