using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal class Token
    {
        public TokenName Name { get; }
        public string Value { get; }
        public int Line { get; }
        public int Column { get; }

        public Token(TokenName name, string value, int line, int column)
        {
            Name = name;
            Value = value;
            Line = line;
            Column = column;
        }
    }
}
