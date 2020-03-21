using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal class ArrayValidator : IArrayValidator
    {
        private readonly IElementExtractor _elementExtractor;

        public ArrayValidator(IElementExtractor elementExtractor)
        {
            _elementExtractor = elementExtractor;
        }

        public ValidationResult Validate(Token token, ITokenCollection tokenCollection, IEnumerable<IArrayFilterer> filterers)
        {
            var startArrayToken = tokenCollection.TakeToken();
            if (startArrayToken.Name != TokenName.StartArray)
                return Error(token, "Required value is supposed to be an array.");

            IReadOnlyCollection<Token> elementTokens;
            try
            {
                elementTokens = _elementExtractor.GetElementTokens(tokenCollection);
            }
            catch (ArrayEndMissingException e)
            {
                return Error(token, e.Message);
            }

            foreach (var filterer in filterers)
            {
                var result = filterer.GetInvalidTokens(elementTokens);
                if (result.Any())
                    return Error(token, filterer.Message);
            }

            return ValidationResult.Success();
        }

        private static ValidationResult Error(Token token, string message)
        {
            var error = new ParserError(message, token.Line, token.Column);
            return ValidationResult.Error(error);
        }
    }
}
