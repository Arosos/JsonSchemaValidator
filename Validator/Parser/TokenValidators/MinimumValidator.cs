using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class MinimumValidator : ITokenValidator
    {
        private readonly IIntegerTokenValueValidator _integerTokenValueValidator;

        public MinimumValidator(IIntegerTokenValueValidator integerTokenValueValidator)
        {
            _integerTokenValueValidator = integerTokenValueValidator;
        }

        public TokenName TokenName => new TokenName(new MinimumKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var result = _integerTokenValueValidator.Validate(token, tokenCollection);
            return result;
        }
    }
}
