using System;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Exceptions
{
    [Serializable]
    public class InvalidTypeTokenValueException : Exception
    {
        public string InvalidValue { get; }

        public InvalidTypeTokenValueException(string invalidValue) : base($"Type token had invalid value: {invalidValue}")
        {
            InvalidValue = invalidValue;
        }

        public InvalidTypeTokenValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
