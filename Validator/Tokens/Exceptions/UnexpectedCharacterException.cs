using System;

namespace JsonSchemaValidator.Validator.Tokens.Exceptions
{
    [Serializable]
    public class UnexpectedCharacterException : Exception
    {
        public char Character { get; }
        public int LineNumber { get; }

        public UnexpectedCharacterException(char character, int lineNumber)
            : base($"Unexpected character: {character} on line {lineNumber}.")
        {
            Character = character;
            LineNumber = lineNumber;
        }

        public UnexpectedCharacterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
