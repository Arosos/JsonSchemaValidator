namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class StringTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.String;

        public string Regex => @""".*?""";
    }
}
