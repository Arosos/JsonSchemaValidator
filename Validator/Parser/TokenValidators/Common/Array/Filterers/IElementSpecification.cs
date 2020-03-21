using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal interface IElementSpecification
    {
        string Message { get; }
        bool IsSatisfied(Token token);
    }
}
