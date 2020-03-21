namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class EndObjectTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.EndObject;

        public string Regex => "}";
    }
}
