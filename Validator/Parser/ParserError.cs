namespace JsonSchemaValidator.Validator.Parser
{
    public class ParserError
    {
        public string Message { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public ParserError(string message, int lineNumber, int columnNumber)
        {
            Message = message;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
