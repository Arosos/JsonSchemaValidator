using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace JsonSchemaValidator.Validator.Tokens.Keywords
{
    // TODO: possible improvement is to make it lazy and cached
    internal class KeywordFactory : IKeywordFactory
    {
        public IReadOnlyCollection<IKeyword> GetKeywords()
        {
            var result = Assembly
                .GetAssembly(typeof(IKeyword))
                .GetTypes()
                .Where(type => typeof(IKeyword).IsAssignableFrom(type))
                .Where(type => !type.IsAbstract)
                .Select(type => Activator.CreateInstance(type))
                .Cast<IKeyword>()
                .ToImmutableHashSet();
            return result;
        }
    }
}
