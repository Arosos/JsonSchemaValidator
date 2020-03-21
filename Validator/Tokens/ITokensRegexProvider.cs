using System.Text.RegularExpressions;

namespace JsonSchemaValidator.Validator.Tokens
{
    internal interface ITokensRegexProvider
    {
        Regex GetRegex();
    }
}