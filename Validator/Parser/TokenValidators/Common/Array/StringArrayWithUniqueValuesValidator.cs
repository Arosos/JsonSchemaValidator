using System;
using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal class StringArrayWithUniqueValuesValidator : IStringArrayWithUniqueValuesValidator
    {
        public ValidationResult Validate(Token token, ITokenCollection tokenCollection, IElementSpecification specification = null)
        {
            var startArrayToken = tokenCollection.TakeToken();
            if (startArrayToken.Name != TokenName.StartArray)
                return Error(token, "Required value is supposed to be an array.");

            IReadOnlyCollection<Token> elementTokens = new List<Token>();
            try
            {
                elementTokens = GetElementTokens(tokenCollection);
            }
            catch (ArrayEndMissingException e)
            {
                return Error(token, e.Message);
            }

            var wrongTypeElementTokens = elementTokens
                .Where(element => element.Name != TokenName.String)
                .ToList();
            if (wrongTypeElementTokens.Any())
                return Error(token, "All elements of array are supposed to be string");

            var recurringElements = elementTokens
                .GroupBy(token => token.Value, StringComparer.OrdinalIgnoreCase)
                .Where(group => group.Count() > 1)
                .ToList();
            if (recurringElements.Any())
                return Error(token, "Elements of array should be unique.");

            specification ??= AlwaysSatifiedSpecification.Instance;
            var elementsNotFulfillingSpecification = elementTokens
                .Where(token => !specification.IsSatisfied(token))
                .ToList();
            if (elementsNotFulfillingSpecification.Any())
                return Error(token, specification.Message);

            return ValidationResult.Success();
        }

        private static ValidationResult Error(Token token, string message)
        {
            var error = new ParserError(message, token.Line, token.Column);
            return ValidationResult.Error(error);
        }

        private static IReadOnlyCollection<Token> GetElementTokens(ITokenCollection tokenCollection)
        {
            // TODO: it should be required that elements are separedted by comma
            var result = new List<Token>();
            var possibleTokenToAdd = tokenCollection.TakeToken();
            while (possibleTokenToAdd.Name != TokenName.EndArray)
            {
                if (possibleTokenToAdd is null)
                    throw new ArrayEndMissingException();
                if (possibleTokenToAdd.Name != TokenName.Comma)
                    result.Add(possibleTokenToAdd);
                possibleTokenToAdd = tokenCollection.TakeToken();
            }
            return result;
        }
    }
}
