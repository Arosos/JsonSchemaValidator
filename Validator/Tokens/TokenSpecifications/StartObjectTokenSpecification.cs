namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class StartObjectTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.StartObject;

        public string Regex => "{";
    }
}
