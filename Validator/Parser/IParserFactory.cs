namespace JsonSchemaValidator.Validator.Parser
{
    internal interface IParserFactory
    {
        IParser Create(ITokenCollection tokenCollection);
    }
}
