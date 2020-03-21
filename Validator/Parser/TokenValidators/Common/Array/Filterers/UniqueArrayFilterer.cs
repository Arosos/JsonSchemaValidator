using System;
using System.Collections.Generic;
using System.Linq;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators.Common.Array.Filterers
{
    internal class UniqueArrayFilterer : IArrayFilterer
    {
        public string Message => "All elements are supposed to be unique.";

        public IReadOnlyCollection<Token> GetInvalidTokens(IEnumerable<Token> tokens)
        {
            var result = tokens
                .GroupBy(token => token.Value, StringComparer.OrdinalIgnoreCase)
                .Where(group => group.Count() > 1)
                .SelectMany(group => group)
                .ToList();
            return result;
        }
    }
}
