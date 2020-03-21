using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Type
{
    internal class TypeElementSpecification : ITypeElementSpecification
    {
        private readonly IReadOnlyCollection<string> _primitiveTypes;

        public TypeElementSpecification(IEnumerable<string> primitiveTypes)
        {
            _primitiveTypes = primitiveTypes.ToImmutableHashSet(StringComparer.OrdinalIgnoreCase);
        }

        public string Message => $"Type elements are supposed to be one of values: {string.Join(", ", _primitiveTypes)}";

        public bool IsSatisfied(Token token)
        {
            return _primitiveTypes.Contains(token.Value);
        }
    }
}
