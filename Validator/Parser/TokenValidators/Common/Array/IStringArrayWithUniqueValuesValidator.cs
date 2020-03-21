using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal interface IStringArrayWithUniqueValuesValidator
    {
        ValidationResult Validate(Token token, ITokenCollection tokenCollection, IElementSpecification specification);
    }
}