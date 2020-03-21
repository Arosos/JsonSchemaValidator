namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal interface ITokenSpecification
    {
        public TokenName Name { get; }
        public string Regex { get; }
    }
}
