using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using JsonSchemaValidator.Validator.Tokens.Exceptions;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal class Tokenizer : ITokenizer
    {
        private readonly IKeywordTokenizer _keywordTokenizer;
        private readonly ITokensRegexProvider _tokensRegexProvider;

        public Tokenizer(IKeywordTokenizer keywordTokenizer, ITokensRegexProvider tokensRegexProvider)
        {
            _keywordTokenizer = keywordTokenizer;
            _tokensRegexProvider = tokensRegexProvider;
        }

        public IEnumerable<Token> GetTokens(string input)
        {
            string trimmedInput = TrimInput(input);
            var lineNumber = 1;
            int currentPosition = 0;
            var lineStart = 0;
            var regex = _tokensRegexProvider.GetRegex();
            var match = regex.Match(trimmedInput);
            while (match.Success)
            {
                var type = GetTokenName(match);
                if (type == TokenName.NewLine)
                {
                    lineStart = currentPosition;
                    lineNumber++;
                }
                else if (!TokenName.IsSkippable(type))
                {
                    var value = match.Groups[type.Name]?.Value;
                    var nextTokenName = GetTokenName(match.NextMatch());
                    type = _keywordTokenizer.TransformToIdentifierIfNeccessary(type, nextTokenName, value);
                    yield return new Token(type, value, lineNumber, match.Index - lineStart);
                }
                currentPosition = match.Index + match.Length;
                match = regex.Match(trimmedInput, currentPosition);
            }

            if (currentPosition != trimmedInput.Length)
                throw new UnexpectedCharacterException(trimmedInput[currentPosition], lineNumber);

            yield return new Token(TokenName.EndOfFile, string.Empty, lineNumber, currentPosition - lineStart);
        }

        private static TokenName GetTokenName(Match match)
        {
            var groupName = match.Groups.Values.Skip(1).SingleOrDefault(value => value.Success)?.Name;
            return new TokenName(groupName);
        }

        private static string TrimInput(string input)
        {
            var trimmedInput = input.Trim();
            if (!trimmedInput.StartsWith("{") || !trimmedInput.EndsWith("}"))
                throw new InvalidJsonSchemaException("Lacks: '{' at the beginning or '}' at the end.");

            trimmedInput = trimmedInput[1..^1];
            return trimmedInput;
        }

        private static readonly Regex _trimEndRegex = new Regex(@"\s*$");

        private static string TrimEndFromWhiteSpace(string input)
        {
            return _trimEndRegex.Replace(input, string.Empty);
        }
    }
}
