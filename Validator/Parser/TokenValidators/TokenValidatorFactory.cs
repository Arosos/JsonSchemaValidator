using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class TokenValidatorFactory : ITokenValidatorFactory
    {
        private readonly IReadOnlyCollection<ITokenValidator> _tokenValidators;

        public TokenValidatorFactory(IEnumerable<ITokenValidator> tokenValidators)
        {
            _tokenValidators = tokenValidators.ToList();
        }

        public ITokenValidator GetTokenValidator(Token token)
        {
            var tokenValidator = _tokenValidators.SingleOrDefault(validator => validator.TokenName == token.Name);
            return tokenValidator;
        }
    }
}
