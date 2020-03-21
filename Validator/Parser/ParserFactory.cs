using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;

namespace JsonSchemaValidator.Validator.Parser
{
    internal class ParserFactory : IParserFactory
    {
        public IParser Create(ITokenCollection tokenCollection)
        {
            var tokenHandlerFactory = GetTokenValidatorFactory();
            return new Parser(tokenCollection, tokenHandlerFactory);
        }

        private static ITokenValidatorFactory GetTokenValidatorFactory()
        {
            var tokenValidators = GetTokenValidators();
            return new TokenValidatorFactory(tokenValidators);
        }

        private static IReadOnlyCollection<ITokenValidator> GetTokenValidators()
        {
            return new List<ITokenValidator>
            {
                new IdValidator(),
                new CommaValidator(),
                new SchemaValidator(),
                new TitleValidator(GetStringTokenValueValidator()),
                new RequiredValidator(GetStringArrayWithUniqueValuesValidator()),
            };
        }

        private static IStringTokenValueValidator GetStringTokenValueValidator()
        {
            return new StringTokenValueValidator();
        }

        private static IStringArrayWithUniqueValuesValidator GetStringArrayWithUniqueValuesValidator()
        {
            return new StringArrayWithUniqueValuesValidator();
        }
    }
}
