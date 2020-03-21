using System.Collections.Generic;

namespace JsonSchemaValidator.Validator.Tokens.TokenSpecifications
{
    internal class TokenSpecificationFactory : ITokenSpecificationFactory
    {
        public IReadOnlyCollection<ITokenSpecification> GetTokenSpecifications()
        {
            return new List<ITokenSpecification>
            {
                new ColonTokenSpecification(),
                new CommaTokenSpecification(),
                new NewLineTokenSpecification(),
                new NumberTokenSpecification(),
                new SkipTokenSpecification(),
                new StringTokenSpecification(),
                new StartArrayTokenSpecification(),
                new EndArrayTokenSpecification(),
                new StartObjectTokenSpecification(),
                new EndObjectTokenSpecification(),
            };
        }
    }
}
