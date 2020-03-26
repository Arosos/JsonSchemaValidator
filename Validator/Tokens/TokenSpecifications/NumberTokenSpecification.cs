namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class NumberTokenSpecification : ITokenSpecification
    {
        public TokenName Name => TokenName.Number;

        public string Regex => @"-{0,1}\d+(\.\d*)?";
    }
}
