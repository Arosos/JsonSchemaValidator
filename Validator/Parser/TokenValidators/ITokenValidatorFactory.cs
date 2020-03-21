using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal interface ITokenValidatorFactory
    {
        ITokenValidator GetTokenValidator(Token token);
    }
}
