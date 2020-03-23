using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class MaximumValidator : ITokenValidator
    {
        private readonly IIntegerTokenValueValidator _integerTokenValueValidator;

        public MaximumValidator(IIntegerTokenValueValidator integerTokenValueValidator)
        {
            _integerTokenValueValidator = integerTokenValueValidator;
        }

        public TokenName TokenName => new TokenName(new MaximumKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            return _integerTokenValueValidator.Validate(token, tokenCollection);
        }
    }
}
