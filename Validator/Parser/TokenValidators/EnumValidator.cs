using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class EnumValidator : ITokenValidator
    {
        private readonly IArrayValidator _arrayValidator;
        private readonly IReadOnlyCollection<IArrayFilterer> _arrayFilterers;

        public EnumValidator(IArrayValidator arrayValidator, IEnumerable<IArrayFilterer> arrayFilterers)
        {
            _arrayValidator = arrayValidator;
            _arrayFilterers = arrayFilterers.ToList();
        }

        public TokenName TokenName => new TokenName(new EnumKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            return new[] { _arrayValidator.Validate(token, tokenCollection, _arrayFilterers) };
        }
    }
}
