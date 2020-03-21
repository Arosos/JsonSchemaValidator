using System.Collections.Generic;

namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal interface ITokenSpecificationFactory
    {
        IReadOnlyCollection<ITokenSpecification> GetTokenSpecifications();
    }
}
