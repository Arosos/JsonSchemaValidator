using System;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Exceptions
{
    [Serializable]
    public class ArrayElementSeparatorException : Exception
    {
        public ArrayElementSeparatorException() : base($"Array separator is supposed to be: '{TokenName.Comma}'.")
        {
        }

        public ArrayElementSeparatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
