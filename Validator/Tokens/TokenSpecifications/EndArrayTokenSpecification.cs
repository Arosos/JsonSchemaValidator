namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class EndArrayTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.EndArray;

        public string Regex => @"\]";
    }
}
