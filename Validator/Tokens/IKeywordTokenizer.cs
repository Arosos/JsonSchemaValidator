using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal interface IKeywordTokenizer
    {
        TokenName TransformToIdentifierIfNeccessary(TokenName tokenName, TokenName nextTokenName, string value);
    }
}