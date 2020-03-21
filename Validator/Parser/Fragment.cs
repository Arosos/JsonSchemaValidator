namespace JsonSchemaValidator.Validator.Parser
{
    internal struct Fragment
    {
        public string Value { get; }

        public Fragment(string value)
        {
            Value = value;
        }

        public static Fragment Empty => new Fragment(EmptyValue);

        private const string EmptyValue = "#";
    }
}
