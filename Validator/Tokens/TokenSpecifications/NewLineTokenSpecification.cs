namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class NewLineTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.NewLine;

        public string Regex => @"\r\n|\n";
    }
}
