using System.Linq;
using System.Text.RegularExpressions;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal class TokensRegexProvider : ITokensRegexProvider
    {
        private readonly ITokenSpecificationFactory _tokenSpecificationFactory;

        public TokensRegexProvider(ITokenSpecificationFactory tokenSpecificationFactory)
        {
            _tokenSpecificationFactory = tokenSpecificationFactory;
        }

        public Regex GetRegex()
        {
            var tokenSpecifications = _tokenSpecificationFactory.GetTokenSpecifications();
            var regex = new Regex(string.Join("|", tokenSpecifications.Select(GetSpecificationRegex)));
            return regex;
        }

        private static string GetSpecificationRegex(ITokenSpecification specification)
        {
            return $"(?<{specification.Name}>{specification.Regex})";
        }
    }
}
