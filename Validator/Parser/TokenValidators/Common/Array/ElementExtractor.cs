using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal class ElementExtractor : IElementExtractor
    {
        public IReadOnlyCollection<Token> GetElementTokens(ITokenCollection tokenCollection)
        {
            var result = new List<Token>();
            Token possibleTokenToAdd, possibleTerminatorToken;
            do
            {
                possibleTokenToAdd = tokenCollection.TakeToken();
                possibleTerminatorToken = tokenCollection.TakeToken();
                if (possibleTerminatorToken is null || possibleTokenToAdd is null)
                    throw new ArrayEndMissingException();
                if (possibleTokenToAdd.Name != TokenName.Comma)
                    result.Add(possibleTokenToAdd);
                if (possibleTerminatorToken.Name != TokenName.Comma && possibleTerminatorToken.Name != TokenName.EndArray)
                    throw new ArrayElementSeparatorException();
            } while (possibleTerminatorToken.Name != TokenName.EndArray);
            return result;
        }
    }
}
