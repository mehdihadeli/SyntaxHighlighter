using SyntaxHighlighter.Formatters;
using SyntaxHighlighter.Lexers;
using SyntaxHighlighter.Styles;

string csharpSourceCode =
    @"```csharp
using System;

namespace SampleNamespace
{
    public class SampleClass
    {
        // A constant
        const int MaxValue = 100;

        // Entry point of the program
        static void Main(string[] args)
        {
            // Declare variables
            int number = 10;
            bool isEven = (number % 2 == 0);
            
            // Output
            Console.WriteLine($""Is the number {number} even? {isEven}"");

            // Loop
            for (int i = 0; i < MaxValue; i++)
            {
                Console.WriteLine(i);
            }

            // Function call
            DoSomething();
        }
    }
}";

Lexer lexer = new CSharpLexer();
Formatter formatter = new ConsoleFormatter256();
var style = await Style.LoadThemeByName("dracula");

var tokens = lexer.Tokenize(csharpSourceCode);
formatter.Format(tokens, Console.Out, style);
Console.WriteLine(); 

Console.ReadKey();
