namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class SkipTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.Skip;

        public string Regex => @"\s";
    }
}
