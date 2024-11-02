# Syntax Highlighter

A powerful `Syntax Highlighting` library inspired by [Pygments](https://github.com/pygments/pygments) and [Chroma](https://github.com/alecthomas/chroma), designed for versatility and ease of use. 

This library allows you to define styles, formatters, lexers, and tokens for highlighting code snippets across various programming languages.

## Features

- **Lexer Support**: Easily create lexers for different programming languages.
- **Styles**: You can define and use styles based on a [JSON file](./src/Styles/dracula.json), with configurations based on token types. This allows you to customize the appearance of highlighted code elements, such as keywords, strings, and comments, enhancing readability and visual appeal.
- **Formatters**: Format highlighted code output in various ways (HTML, terminal, bbcode, etc.).
- **Tokenization**: Break down source code into meaningful tokens for better syntax highlighting.

## Installation
TODO..

## Usage
Here is a quick guide on how to use the syntax highlighter in your project.

```csharp
class Program
{
    static void Main()
    {
        string code = @"public class HelloWorld
                        {
                            public static void Main(string[] args)
                            {
                                Console.WriteLine(""Hello, World!"");
                            }
                        }";

        Lexer lexer = new CSharpLexer();
        Formatter formatter = new ConsoleFormatter256();
        var style = await Style.LoadFromJsonAsync("dracula.json");
        
        var tokens = lexer.Tokenize(csharpSourceCode);
        formatter.Format(tokens, Console.Out, style);
        Console.WriteLine(); 
    }
} 
```

## Lexers

Lexers are responsible for breaking down the code into tokens. You can create a custom lexer by extending the Lexer class.

```csharp
public class NewLanguageLexer : Lexer
{
    // Implement required methods here
}
```

## Style

You can create and use custom style themes through a [JSON file](src/Styles/dracula.json), which allows for flexible configuration of the appearance of highlighted code. An example of a default theme is dracula.json, which might look like this:

```json
{
  "name": "Dracula",
  "foreground": "#f8f8f2",
  "background": "#44475a",
  "margin": 2,
  "styles": {
    "keyword": {
      "foreground": "#8be9fd",
      "bold": true
    },
    "comment": {
      "foreground": "#6272a4",
      "italic": true
    }
    // Additional token styles...
  }
}

```

In this structure, you can define specific styles based on token types (like `keyword` and `comment`), customizing attributes such as colors and font weights. 
This enables users to enhance the readability and aesthetic appeal of syntax-highlighted content according to their preferences.

## Supported Languages

- [x] C#
- [x] Golang
- [ ] Rust
- [ ] Java
- [ ] Typescript
- [ ] Javascript
- [ ] Python

## Contributing
Contributions are welcome! If you would like to contribute to the project, please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
