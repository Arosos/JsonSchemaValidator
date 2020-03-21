using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class RequiredValidator : ITokenValidator
    {
        private readonly IArrayValidator _stringArrayWithUniqueValuesValidator;
        private readonly IReadOnlyCollection<IArrayFilterer> _arrayFilterers;

        public RequiredValidator(IArrayValidator stringArrayWithUniqueValuesValidator, IEnumerable<IArrayFilterer> arrayFilterers)
        {
            _stringArrayWithUniqueValuesValidator = stringArrayWithUniqueValuesValidator;
            _arrayFilterers = arrayFilterers.ToList();
        }

        public TokenName TokenName => new TokenName(new RequiredKeyword().Keyword);

        public ValidationResult Validate(Token token, ITokenCollection tokenCollection)
        {
            return _stringArrayWithUniqueValuesValidator.Validate(token, tokenCollection, _arrayFilterers);
        }
    }
}
