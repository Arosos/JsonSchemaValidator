using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal class KeywordTokenizer : IKeywordTokenizer
    {
        private readonly IReadOnlyCollection<string> _keyWords;

        public KeywordTokenizer(IKeywordFactory keywordFactory)
        {
            _keyWords = keywordFactory.GetKeywords().Select(keyword => keyword.Keyword).ToImmutableHashSet(StringComparer.OrdinalIgnoreCase);
        }

        public TokenName TransformToIdentifierIfNeccessary(TokenName tokenName, TokenName nextTokenName, string value)
        {
            var trimmedValue = value.Trim('"');
            return IsKeyword(tokenName, nextTokenName, trimmedValue)
                ? new TokenName(trimmedValue)
                : tokenName;
        }

        private bool IsKeyword(TokenName tokenName, TokenName nextTokenName, string value)
        {
            return tokenName == TokenName.String && nextTokenName == TokenName.Colon && _keyWords.Contains(value);
        }
    }
}
