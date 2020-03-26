using System;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions
{
    [Serializable]
    public class EmptyArrayException : Exception
    {
        public EmptyArrayException() : base("Array was supposed to have at least one element")
        {
        }

        public EmptyArrayException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
