using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JsonSchemaValidator.Validator.Parser;
using JsonSchemaValidator.Validator.Tokens;

namespace JsonSchemaValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInput(args);
            var tokenizer = new TokenizerFactory().Create();
            var tokens = tokenizer.GetTokens(input).ToList();
            var tokenCollection = new TokenCollection(tokens);
            var parser = new ParserFactory().Create(tokenCollection);
            var parserResult = parser.Parse();
            if (parserResult.ParserErrors.Any())
            {
                Console.WriteLine("Errors:");
                parserResult.ParserErrors.ToList().ForEach(error => Console.WriteLine($"({error.LineNumber},{error.ColumnNumber}): {error.Message}"));
            }
            else
            {
                Console.WriteLine("Success!");
            }
            Console.WriteLine("Press any key...");
            if (!Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }

        private static string GetInput(string[] args)
        {
            var inputArgument = args
                .Select((arg, index) => (arg, index))
                .Where(pair => string.Equals(pair.arg, "-input", StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (inputArgument.Count == 1)
            {
                var path = GetInputPath(args, inputArgument.Single().index);
                return File.ReadAllText(path);
            }
            else
            {
                return GetDefaultFile();
            }
        }

        private static string GetDefaultFile()
        {
            return File.ReadAllText("exampleFile.txt");
        }

        private static string GetInputPath(string[] args, int index)
        {
            var inputValueIndex = index + 1;
            return args.Length > inputValueIndex
                ? args[inputValueIndex]
                : throw new ArgumentException($"Input parameter not found", nameof(args));
        }
    }
}
