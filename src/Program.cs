using SyntaxHighlighter.Formatters;
using SyntaxHighlighter.Lexers;
using SyntaxHighlighter.Styles;

string goSourceCode =
    @"```go
package main

import (
	""fyne.io/fyne/v2/app""
	""fyne.io/fyne/v2/container""
	""fyne.io/fyne/v2/widget""
)

func main() {
	myApp := app.New()
	myWindow := myApp.NewWindow(""Opacity Example"")

    int i:= 1

	// Create a container with a semi-transparent background
	content := container.NewVBox(
		widget.NewLabel(""This is some text with a semi-transparent background""),
	)

	// Setting a custom background color with opacity
	content.SetBackgroundColor(fyne.NewColor(255, 0, 0, 128)) // RGBA

	myWindow.SetContent(content)
	myWindow.ShowAndRun()
}
```";

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

var style = await Style.LoadFromJsonAsync("dracula.json");

var tokens = lexer.Tokenize(csharpSourceCode);
formatter.Format(tokens, Console.Out, style);

Console.WriteLine(); // Ensures the next prompt starts on a new line

Console.ReadKey();
