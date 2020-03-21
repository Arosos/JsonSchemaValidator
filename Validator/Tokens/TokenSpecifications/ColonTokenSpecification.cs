namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class ColonTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.Colon;

        public string Regex => ":";
    }
}
