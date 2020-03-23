using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class MinLengthValidator : ITokenValidator
    {
        private readonly INonNegativeIntegerValueValidator _nonNegativeIntegerValueValidator;

        public MinLengthValidator(INonNegativeIntegerValueValidator nonNegativeIntegerValueValidator)
        {
            _nonNegativeIntegerValueValidator = nonNegativeIntegerValueValidator;
        }

        public TokenName TokenName => new TokenName(new MinLengthKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            return _nonNegativeIntegerValueValidator.Validate(token, tokenCollection);
        }
    }
}
