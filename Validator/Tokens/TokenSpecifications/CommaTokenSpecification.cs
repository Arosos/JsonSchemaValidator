namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class CommaTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.Comma;

        public string Regex => ",";
    }
}
