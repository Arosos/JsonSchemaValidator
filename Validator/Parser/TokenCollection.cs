using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser
{
    internal class TokenCollection : ITokenCollection
    {
        private readonly IReadOnlyList<Token> _tokens;
        private int _position = 0;

        public TokenCollection(IEnumerable<Token> tokens)
        {
            _tokens = tokens.ToList();
        }

        public Token TakeToken()
        {
            var token = Peek();
            _position++;
            return token;
        }

        public Token Peek()
        {
            var token = _position < _tokens.Count
                ? _tokens[_position]
                : null;
            return token;
        }
    }
}
