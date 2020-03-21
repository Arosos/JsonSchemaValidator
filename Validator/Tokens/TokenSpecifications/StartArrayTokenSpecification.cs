namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class StartArrayTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.StartArray;

        public string Regex => @"\[";
    }
}
