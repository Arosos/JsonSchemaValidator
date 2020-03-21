namespace JsonSchemaValidator.Validator.Parser
{
    internal class ValidationResult
    {
        public ParserError ParserError { get; } = null;
        public bool IsSuccess => ParserError is null;

        private ValidationResult()
        {
        }

        private ValidationResult(ParserError parserError) : this() => ParserError = parserError;

        public static ValidationResult Success() => new ValidationResult();

        public static ValidationResult Error(ParserError parserError) => new ValidationResult(parserError);
    }
}
