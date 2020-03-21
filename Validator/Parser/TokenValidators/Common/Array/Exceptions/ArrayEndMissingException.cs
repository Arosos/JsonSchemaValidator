using System;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions
{
    [Serializable]
    public class ArrayEndMissingException : Exception
    {
        public ArrayEndMissingException() : base("Array closing bracket was missing.")
        {
        }

        public ArrayEndMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
