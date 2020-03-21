using System;

namespace JsonSchemaValidator.Validator.Tokens.Exceptions
{
    [Serializable]
    public class InvalidJsonSchemaException : Exception
    {
        public InvalidJsonSchemaException(string message) : base($"Invalid schema: {message}")
        {

        }

        public InvalidJsonSchemaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
