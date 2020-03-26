using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Object;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Type;
using JsonSchemaValidator.Validator.Tokens.Keywords;

namespace JsonSchemaValidator.Validator.Parser
{
    internal class ParserFactory : IParserFactory
    {
        public IParser Create(ITokenCollection tokenCollection)
        {
            var tokenHandlerFactory = GetParserTokenValidatorFactory();
            return new Parser(tokenCollection, tokenHandlerFactory);
        }

        private static ITokenValidatorFactory GetParserTokenValidatorFactory()
        {
            var tokenValidators = GetParserTokenValidators();
            return new TokenValidatorFactory(tokenValidators);
        }

        private static ITokenValidatorFactory GetObjectTokenValidatorFactory()
        {
            var tokenValidators = GetObjectTokenValidators();
            return new TokenValidatorFactory(tokenValidators);
        }

        private static List<ITokenValidator> GetParserTokenValidators()
        {
            var result = new List<ITokenValidator>
            {
                new IdValidator(),
                new SchemaValidator(),
                new TitleValidator(GetStringTokenValueValidator()),
                GetRequiredValidator(),
                GetTypeValidator(),
                GetPropertiesValidator(),
                new DefinitionsValidator(GetObjectValidator()),
            };
            return result;
        }

        private static List<ITokenValidator> GetObjectTokenValidators()
        {
            return new List<ITokenValidator>
            {
                GetRequiredValidator(),
                GetTypeValidator(),
                new MinimumValidator(GetIntegerTokenValueValidator()),
                new MaximumValidator(GetIntegerTokenValueValidator()),
                GetStringTokenValueValidator(),
                GetIntegerTokenValueValidator(),
                new DescriptionValidator(GetStringTokenValueValidator()),
                new MinLengthValidator(GetNonNegativeIntegerTokenValueValidator()),
                new MaxLengthValidator(GetNonNegativeIntegerTokenValueValidator()),
                new RefValidator(GetStringTokenValueValidator()),
                GetEnumValidator(),
            };
        }

        private static EnumValidator GetEnumValidator()
        {
            var arrayFilterers = new List<IArrayFilterer>
            {
                new AtLeastOnetArrayFilterer(),
                new UniqueArrayFilterer(),
            };
            return new EnumValidator(GetArrayValidator(), arrayFilterers);
        }

        private static PropertiesValidator GetPropertiesValidator()
        {
            var objectValidator = GetObjectValidator();
            return new PropertiesValidator(objectValidator);
        }

        private static ObjectValidator GetObjectValidator()
        {
            var tokenValidatorFactory = GetObjectTokenValidatorFactory();
            return new ObjectValidator(tokenValidatorFactory, GetArrayValidator(), new KeywordFactory());
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
            // TODO: it is supposed to be some provider but for now it suffices
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

        private static INonNegativeIntegerValueValidator GetNonNegativeIntegerTokenValueValidator()
        {
            return new NonNegativeIntegerValueValidator(GetIntegerTokenValueValidator());
        }

        private static IIntegerTokenValueValidator GetIntegerTokenValueValidator() => new IntegerTokenValueValidator();

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
