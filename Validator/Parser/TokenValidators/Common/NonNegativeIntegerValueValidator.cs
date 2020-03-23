using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal class NonNegativeIntegerValueValidator : INonNegativeIntegerValueValidator
    {
        private readonly IIntegerTokenValueValidator _integerTokenValueValidator;

        public NonNegativeIntegerValueValidator(IIntegerTokenValueValidator integerTokenValueValidator)
        {
            _integerTokenValueValidator = integerTokenValueValidator;
        }

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.Peek();
            var integerResult = _integerTokenValueValidator.Validate(token, tokenCollection).Single();
            int.TryParse(value.Value, out var integerValue);
            if (!integerResult.IsSuccess || integerValue < 0)
            {
                var error = new ParserError($"{token.Name} is not non negative integer.", token.Line, token.Column);
                return new[] { ValidationResult.Error(error) };
            }
            return new[] { ValidationResult.Success() };
        }
    }
}
