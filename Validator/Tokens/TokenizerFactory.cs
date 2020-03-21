using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal class TokenizerFactory : ITokenizerFactory
    {
        public ITokenizer Create()
        {
            var keywordTokenizer = GetKeywordTokenizer();
            var tokensRegexProvider = GetTokensRegexProvider();
            return new Tokenizer(keywordTokenizer, tokensRegexProvider);
        }

        private static IKeywordTokenizer GetKeywordTokenizer()
        {
            var keywordFactory = new KeywordFactory();
            var keywordTokenizer = new KeywordTokenizer(keywordFactory);
            return keywordTokenizer;
        }

        private static ITokensRegexProvider GetTokensRegexProvider()
        {
            var tokenSpecificationFactory = new TokenSpecificationFactory();
            var tokensRegexProvider = new TokensRegexProvider(tokenSpecificationFactory);
            return tokensRegexProvider;
        }
    }
}
