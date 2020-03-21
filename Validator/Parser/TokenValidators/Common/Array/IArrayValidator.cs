using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array
{
    internal interface IArrayValidator
    {
        ValidationResult Validate(Token token, ITokenCollection tokenCollection, IEnumerable<IArrayFilterer> filterers);
    }
}
