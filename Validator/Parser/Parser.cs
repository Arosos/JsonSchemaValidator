using System;
using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser
{
    internal class Parser : IParser
    {
        private readonly List<ParserError> _parserErrors = new List<ParserError>();
        private readonly ITokenCollection _tokenCollection;
        private readonly ITokenValidatorFactory _tokenHandlerFactory;

        public Parser(ITokenCollection tokenCollection, ITokenValidatorFactory tokenHandlerFactory)
        {
            _tokenCollection = tokenCollection;
            _tokenHandlerFactory = tokenHandlerFactory;
        }

        public ParserResult Parse()
        {
            var token = _tokenCollection.TakeToken();
            while (token != null)
            {
                var colonToken = _tokenCollection.TakeToken();
                if (colonToken.Name != TokenName.Colon)
                {
                    AddError(token, "Identifier must end with colon.");
                    break;
                }
                var tokenValidator = _tokenHandlerFactory.GetTokenValidator(token);
                var validationResult = tokenValidator.Validate(token, _tokenCollection);
                _parserErrors.AddRange(validationResult.Where(r => !r.IsSuccess).Select(r => r.ParserError));

                var commaToken = _tokenCollection.TakeToken();
                if (commaToken.Name == TokenName.EndOfFile)
                {
                    break;
                }
                if (commaToken.Name != TokenName.Comma)
                {
                    AddError(commaToken, "In order to process next identifier the previous one needs to end with comma.");
                    break;
                }
                token = _tokenCollection.TakeToken();
            }
            return new ParserResult(_parserErrors);
        }

        private void AddError(Token token, string message)
        {
            var error = new ParserError(message, token.Line, token.Column);
            _parserErrors.Add(error);
        }

        private class ErrorEventArgs : EventArgs
        {
            public string Message { get; set; }
            public int LineNumber { get; set; }
            public int ColumnNumber { get; set; }
        }
    }
}
