﻿using System.Collections.Generic;
using JsonSchemaValidator.Validator.Parser.TokenValidators.Common;
using JsonSchemaValidator.Validator.Tokens;
using JsonSchemaValidator.Validator.Tokens.Keywords;
using JsonSchemaValidator.Validator.Tokens.TokenSpecifications;

namespace JsonSchemaValidator.Validator.Parser.TokenValidators
{
    internal class TitleValidator : ITokenValidator
    {
        private readonly IStringTokenValueValidator _stringTokenValueValidator;

        public TitleValidator(IStringTokenValueValidator stringTokenValueValidator)
        {
            _stringTokenValueValidator = stringTokenValueValidator;
        }

        public TokenName TokenName => new TokenName(new TitleKeyword().Keyword);

        public IReadOnlyCollection<ValidationResult> Validate(Token token, ITokenCollection tokenCollection)
        {
            return _stringTokenValueValidator.Validate(token, tokenCollection);
        }
    }
}
