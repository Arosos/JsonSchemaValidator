using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Type;

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
                GetRequiredValidator(),
                GetTypeValidator(),
            };
        }

        private static TypeValidator GetTypeValidator()
        {
            var primitiveTypes = GetPrimitiveTypes();
            var typeSpecification = new TypeElementSpecification(primitiveTypes);
            var arrayFilterers = new List<IArrayFilterer>
            {
                GetStringArrayFilterer(),
                GetUniqueArrayFilterer(),
                new SpecificationArrayFilterer(typeSpecification),
            };
            return new TypeValidator(GetArrayValidator(), typeSpecification, arrayFilterers);
        }

        private static IEnumerable<string> GetPrimitiveTypes()
        {
            yield return "null";
            yield return "boolean";
            yield return "object";
            yield return "array";
            yield return "number";
            yield return "string";
            yield return "integer";
        }

        private static RequiredValidator GetRequiredValidator()
        {
            var arrayFilterers = new List<IArrayFilterer>
            {
                GetStringArrayFilterer(),
                GetUniqueArrayFilterer(),
            };
            return new RequiredValidator(GetArrayValidator(), arrayFilterers);
        }

        private static UniqueArrayFilterer GetUniqueArrayFilterer()
        {
            return new UniqueArrayFilterer();
        }

        private static StringArrayFilterer GetStringArrayFilterer()
        {
            return new StringArrayFilterer();
        }

        private static IStringTokenValueValidator GetStringTokenValueValidator()
        {
            return new StringTokenValueValidator();
        }

        private static IArrayValidator GetArrayValidator()
        {
            var elementExtractor = new ElementExtractor();
            return new ArrayValidator(elementExtractor);
        }
    }
}
