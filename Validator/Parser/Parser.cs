using System;
using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators;

namespace JsonSchemaValidator.Validator.Parser
{
    internal class Parser : IParser
    {
        private readonly IList<ParserError> _parserErrors = new List<ParserError>();
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
                try
                {
                    var tokenValidator = _tokenHandlerFactory.GetTokenValidator(token);
                    var validationResult = tokenValidator.Validate(token, _tokenCollection);
                    if (!validationResult.IsSuccess)
                        _parserErrors.Add(validationResult.ParserError);
                    token = _tokenCollection.TakeToken();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new ParserResult(_parserErrors);
        }

        private class ErrorEventArgs : EventArgs
        {
            public string Message { get; set; }
            public int LineNumber { get; set; }
            public int ColumnNumber { get; set; }
        }
    }
}
