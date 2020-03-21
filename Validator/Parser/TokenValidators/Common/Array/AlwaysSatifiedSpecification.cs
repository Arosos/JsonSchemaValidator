using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal class AlwaysSatifiedSpecification : IElementSpecification
    {
        public static IElementSpecification Instance => new AlwaysSatifiedSpecification();

        public string Message => string.Empty;

        public bool IsSatisfied(Token token) => true;
    }
}
