using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Type
{
    internal class TypeValidator : ITokenValidator
    {
        private readonly IStringArrayWithUniqueValuesValidator _stringArrayWithUniqueValuesValidator;
        private readonly ITypeElementSpecification _typeElementSpecification;
        private readonly IStringTokenValueValidator _stringTokenValueValidator;

        public TypeValidator(IStringArrayWithUniqueValuesValidator stringArrayWithUniqueValuesValidator, ITypeElementSpecification typeElementSpecification, IStringTokenValueValidator stringTokenValueValidator)
        {
            _stringArrayWithUniqueValuesValidator = stringArrayWithUniqueValuesValidator;
            _typeElementSpecification = typeElementSpecification;
            _stringTokenValueValidator = stringTokenValueValidator;
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
                var result = _stringArrayWithUniqueValuesValidator.Validate(token, tokenCollection, _typeElementSpecification);
                return result;
            }
            else if (value.Name == TokenName.String)
            {
                if (!_typeElementSpecification.IsSatisfied(value))
                {
                    var error = new ParserError($"{token.Name} string values is ")
                    return ValidationResult.Error(error);

                }
            }
        }
    }
}
