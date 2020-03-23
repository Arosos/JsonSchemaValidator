using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Object;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class PropertiesValidator : ITokenValidator
    {
        private readonly IObjectValidator _objectValidator;

        public PropertiesValidator(IObjectValidator objectValidator)
        {
            _objectValidator = objectValidator;
        }

        public TokenName TokenName => new TokenName(new PropertiesKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var result = _objectValidator.Validate(token, tokenCollection);
            return result;
        }
    }
}
