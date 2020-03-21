using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser
{
    internal interface ITokenCollection
    {
        Token TakeToken();
        Token Peek();
    }
}