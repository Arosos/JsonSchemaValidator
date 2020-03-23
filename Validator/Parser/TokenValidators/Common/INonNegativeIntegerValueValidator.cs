using System.Collections.Generic;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common
{
    internal interface INonNegativeIntegerValueValidator
    {
        IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection);
    }
}