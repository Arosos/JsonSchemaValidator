using System.Collections.Generic;

namespace JsonSchemaValidator.Validator.Tokens.Keywords
{
    internal interface IKeywordFactory
    {
        IReadOnlyCollection<IKeyword> GetKeywords();
    }
}
