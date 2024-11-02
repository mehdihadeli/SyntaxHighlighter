using SyntaxHighlighter.Formatters;
using SyntaxHighlighter.Lexers;
using SyntaxHighlighter.Styles;

string csharpSourceCode =
    @"```csharp
// This is a single-line comment
/*
This is a multi-line comment
*/

using System;

namespace SampleNamespace
{
    class SampleClass
    {
        // A constant
        const int MaxValue = 100;

        // Entry point of the program
        static void Main(string[] args)
        {
            // Declare variables
            int number = 10;
            bool isEven = (number % 2 == 0);
            string message = ""Hello, World!"";
            
            // Output
            Console.WriteLine(message);
            Console.WriteLine($""Is the number {number} even? {isEven}"");

            // Conditional statement
            if (isEven)
            {
                Console.WriteLine($""{number} is even."");
            }
            else
            {
                Console.WriteLine($""{number} is odd."");
            }

            // Loop
            for (int i = 0; i < MaxValue; i++)
            {
                Console.WriteLine(i);
            }

            // Function call
            DoSomething();
        }

        static void DoSomething()
        {
            Console.WriteLine(""Doing something..."");
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
