using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Object;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class DefinitionsValidator : ITokenValidator
    {
        private readonly IObjectValidator _objectValidator;

        public DefinitionsValidator(IObjectValidator objectValidator)
        {
            _objectValidator = objectValidator;
        }

        public TokenName TokenName => new TokenName(new DefinitionsKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            return _objectValidator.Validate(token, tokenCollection);
        }
    }
}
