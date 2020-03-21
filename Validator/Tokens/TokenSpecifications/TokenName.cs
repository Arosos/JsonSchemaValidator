using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal struct TokenName
    {
        public string Name { get; }

        public TokenName(string name) => Name = name;

        public static TokenName Empty => new TokenName();
        public static TokenName StartArray => new TokenName(StartArrayName);
        public static TokenName EndArray => new TokenName(EndArrayName);
        public static TokenName StartObject => new TokenName(StartObjectName);
        public static TokenName EndObject => new TokenName(EndObjectName);
        public static TokenName Number => new TokenName(NumberName);
        public static TokenName String => new TokenName(StringName);
        public static TokenName Colon => new TokenName(ColonName);
        public static TokenName Comma => new TokenName(CommaName);
        public static TokenName NewLine => new TokenName(NewLineName);
        public static TokenName Skip => new TokenName(SkipName);
        public static TokenName EndOfFile => new TokenName(EndOfFileName);

        private static readonly IReadOnlyCollection<TokenName> _skippableTokenNames = new[] { Empty, Colon, Skip }.ToImmutableHashSet();
        public static bool IsSkippable(TokenName tokenName) => _skippableTokenNames.Contains(tokenName);

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is TokenName name &&
                   Name == name.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public static bool operator ==(TokenName left, TokenName right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TokenName left, TokenName right)
        {
            return !(left == right);
        }

        #region consts
        private const string StartArrayName = "START_ARRAY";
        private const string EndArrayName = "END_ARRAY";
        private const string StartObjectName = "START_OBJECT";
        private const string EndObjectName = "END_OBJECT";
        private const string NumberName = "NUMBER";
        private const string StringName = "STRING";
        private const string ColonName = "COLON";
        private const string CommaName = "COMMA";
        private const string NewLineName = "NEW_LINE";
        private const string SkipName = "SKIP";
        private const string EndOfFileName = "END_OF_FILE";
        #endregion
    }
}
