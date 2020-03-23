using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class SchemaValidator : ITokenValidator
    {
        public TokenName TokenName => new TokenName(new SchemaKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.TakeToken();
            if (value is null || value.Name != TokenName.String)
            {
                var error = new ParserError($"Schema value is supposed to be string", value.Line, value.Column);
                return new[] { ValidationResult.Error(error) };
            }
            return new[] { ValidationResult.Success() };
        }
    }
}
