using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal class StringTokenValueValidator : IStringTokenValueValidator
    {
        public ValidationResult Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.TakeToken();
            if (value is null || value.Name != TokenName.String)
            {
                var error = new ParserError($"{token.Name} value is supposed to be string", value.Line, value.Column);
                return ValidationResult.Error(error);
            }
            return ValidationResult.Success();
        }
    }
}
