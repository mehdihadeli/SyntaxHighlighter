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

Lexer lexer = new GoLexer();
Formatter formatter = new ConsoleFormatter256();
var style = await Style.LoadFromJsonAsync("dracula.json");

var tokens = lexer.Tokenize(goSourceCode);
formatter.Format(tokens, Console.Out, style);
Console.WriteLine(); 

Console.ReadKey();
