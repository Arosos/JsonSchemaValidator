using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal interface IElementSpecification
    {
        string Message { get; }
        bool IsSatisfied(Token token);
    }
}
