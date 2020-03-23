using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Object
{
    internal class ObjectValidator : IObjectValidator
    {
        private readonly ITokenValidatorFactory _tokenHandlerFactory;
        private readonly IArrayValidator _arrayValidator;
        private readonly IReadOnlyCollection<TokenName> _keywords;

        public ObjectValidator(ITokenValidatorFactory tokenHandlerFactory, IArrayValidator arrayValidator, IKeywordFactory keywordFactory)
        {
            _tokenHandlerFactory = tokenHandlerFactory;
            _arrayValidator = arrayValidator;
            _keywords = keywordFactory.GetKeywords().Select(keyword => new TokenName(keyword.Keyword)).ToImmutableHashSet();
        }

        public TokenName TokenName => TokenName.StartObject;

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            var errors = new List<ValidationResult>();
            _ = tokenCollection.TakeToken();
            var fieldToken = tokenCollection.TakeToken();
            while (fieldToken.Name != TokenName.EndObject)
            {
                var colonToken = tokenCollection.TakeToken();
                if (fieldToken is null)
                {
                    errors.Add(Error($"{token.Name} does not have closing curly bracket.", token));
                    return errors;
                }

                if (colonToken is null || colonToken.Name != TokenName.Colon)
                {
                    return new[] { Error("Object field is supposed have colon after identifier", colonToken) };
                }

                if (fieldToken.Name != TokenName.String && !_keywords.Contains(fieldToken.Name))
                {
                    return new[] { Error("Inorrect token. It is supposed to be string", token) };
                }

                var valueToken = tokenCollection.Peek();
                if (valueToken.Name == TokenName.StartArray)
                {
                    var result = _arrayValidator.Validate(valueToken, tokenCollection, Enumerable.Empty<IArrayFilterer>());
                    errors.Add(result);
                }
                else if (valueToken.Name == TokenName.StartObject)
                {
                    var result = Validate(valueToken, tokenCollection);
                    errors.AddRange(result);
                }
                else
                {
                    var validator = _keywords.Contains(fieldToken.Name)
                        ? _tokenHandlerFactory.GetTokenValidator(fieldToken)
                        : _tokenHandlerFactory.GetTokenValidator(valueToken);
                    var result = validator.Validate(valueToken, tokenCollection);
                    errors.AddRange(result);
                }

                var terminationToken = tokenCollection.Peek();
                if (terminationToken is null || (terminationToken.Name != TokenName.Comma && terminationToken.Name != TokenName.EndObject))
                {
                    errors.Add(Error($"Expected comma or end of object.", valueToken));
                    return errors;
                }
                if (terminationToken.Name == TokenName.Comma)
                {
                    tokenCollection.TakeToken();
                }
                fieldToken = tokenCollection.TakeToken();
            }
            return errors;
        }

        private static ValidationResult Error(string message, Token token) => ValidationResult.Error(new ParserError(message, token.Line, token.Column));
    }
}
