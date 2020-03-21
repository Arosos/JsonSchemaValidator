using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class RequiredValidator : ITokenValidator
    {
        private readonly IStringArrayWithUniqueValuesValidator _stringArrayWithUniqueValuesValidator;

        public RequiredValidator(IStringArrayWithUniqueValuesValidator stringArrayWithUniqueValuesValidator)
        {
            _stringArrayWithUniqueValuesValidator = stringArrayWithUniqueValuesValidator;
        }

        public TokenName TokenName => new TokenName(new RequiredKeyword().Keyword);

        public ValidationResult Validate(Token token, ITokenCollection tokenCollection)
        {
            return _stringArrayWithUniqueValuesValidator.Validate(token, tokenCollection);
        }
    }
}
