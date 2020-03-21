using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Type
{
    internal class TypeValidator : ITokenValidator
    {
        private readonly IArrayValidator _stringArrayWithUniqueValuesValidator;
        private readonly ITypeElementSpecification _typeElementSpecification;
        private readonly IReadOnlyCollection<IArrayFilterer> _arrayFilterers;

        public TypeValidator(IArrayValidator stringArrayWithUniqueValuesValidator, ITypeElementSpecification typeElementSpecification, IEnumerable<IArrayFilterer> arrayFilterers)
        {
            _stringArrayWithUniqueValuesValidator = stringArrayWithUniqueValuesValidator;
            _typeElementSpecification = typeElementSpecification;
            _arrayFilterers = arrayFilterers.ToList();
        }

        public TokenName TokenName => new TokenName(new TypeKeyword().Keyword);

        public ValidationResult Validate(Token token, ITokenCollection tokenCollection)
        {
            var value = tokenCollection.Peek();
            if (value is null)
            {
                var error = new ParserError($"{token.Name} value is supposed to be string or array.", token.Line, token.Column);
                return ValidationResult.Error(error);
            }
            if (value.Name == TokenName.StartArray)
            {
                var result = _stringArrayWithUniqueValuesValidator.Validate(token, tokenCollection, _arrayFilterers);
                return result;
            }
            else if (value.Name == TokenName.String)
            {
                if (!_typeElementSpecification.IsSatisfied(value))
                {
                    var error = new ParserError($"{token.Name} had invalid value.", token.Line, token.Column);
                    return ValidationResult.Error(error);

                }
            }
            return ValidationResult.Success();
        }
    }
}
