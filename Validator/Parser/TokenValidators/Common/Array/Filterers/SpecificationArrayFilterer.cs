using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal class SpecificationArrayFilterer : IArrayFilterer
    {
        private readonly IElementSpecification _specification;

        public SpecificationArrayFilterer(IElementSpecification specification)
        {
            _specification = specification;
        }

        public string Message => _specification.Message;

        public IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens)
        {
            var result = tokens
                .Where(token => !_specification.IsSatisfied(token))
                .ToList();
            return result;
        }
    }
}
