using SyntaxHighlighter.Styles;
using Console = System.Console;

namespace SyntaxHighlighter.Formatters;

public class ConsoleFormatter256 : Formatter
{
    public override void Format(IEnumerable<Token> tokens, TextWriter writer, Style style)
    {
        // First, set the global background and foreground colors
        string? globalBackground = style.Background;
        string? globalForeground = style.Foreground;
        int globalMargin = style.Margin;

        Console.SetCursorPosition(globalMargin, 0);

        foreach (var token in tokens)
        {
            if (token.Type == TokenType.CodeBlockStart || token.Type == TokenType.CodeBlockEnd)
                continue;

            // Get the style for the current token type
            var tokenStyle = style.Get(token.Type);

            // Build ANSI escape sequence for styling, incorporating global styles
            var escapeCode = BuildAnsiEscapeCode(tokenStyle, globalForeground, globalBackground);

            WriteWithCursorPosition(writer, token.Value, token.Type, escapeCode, globalMargin);
        }

        // Reset all styles after formatting tokens
        writer.Write("\u001b[0m");
    }

    private static void WriteWithCursorPosition(
        TextWriter textWriter,
        string tokenValue,
        TokenType tokenType,
        string escapeCode,
        int margin
    )
    {
        (int left, int top) = Console.GetCursorPosition();
        int consoleHeight = Console.WindowHeight; // Current window height
        int consoleBufferHeight = Console.BufferHeight; // Current buffer height

        // Ensure the buffer is large enough for the content
        if (top + 1 >= consoleBufferHeight)
        {
            // Increase the buffer height if necessary
            Console.BufferHeight = Math.Max(consoleBufferHeight + 10, consoleHeight + 10);
        }

        if (tokenType == TokenType.LineBreak)
        {
            textWriter.Write(escapeCode); // Write styled token to the console
            Console.SetCursorPosition(margin, ++top);
            if (tokenValue.Contains(Environment.NewLine))
                textWriter.Write(tokenValue.Replace(Environment.NewLine, ""));
            else
            {
                textWriter.Write(tokenValue.Replace("\n", ""));
            }
        }
        // else if (tokenType == TokenType.CodeBlockStart || tokenType == TokenType.CodeBlockEnd)
        // {
        //     textWriter.Write(escapeCode); // Write styled token to the console
        //     Console.SetCursorPosition(margin, ++top);
        // }
        else
        {
            textWriter.Write(escapeCode); // Write styled token to the console
            textWriter.Write(tokenValue);
        }

        textWriter.Write("\u001b[0m"); // \u001b[0m resets formatting after each token
    }

    private string BuildAnsiEscapeCode(
        TokenStyle style,
        string? globalForeground,
        string? globalBackground
    )
    {
        var escapeSequence = "";

        // Apply background color: use token's background if specified, otherwise use global
        if (!string.IsNullOrEmpty(style.Background))
        {
            escapeSequence += ConvertHexToAnsiBackground(style.Background);
        }
        else if (!string.IsNullOrEmpty(globalBackground))
        {
            escapeSequence += ConvertHexToAnsiBackground(globalBackground);
            escapeSequence += "\u001b[K";
        }

        // Apply foreground color: use token's foreground if specified, otherwise use global
        if (!string.IsNullOrEmpty(style.Foreground))
        {
            escapeSequence += ConvertHexToAnsiForeground(style.Foreground);
        }
        else if (!string.IsNullOrEmpty(globalForeground))
        {
            escapeSequence += ConvertHexToAnsiForeground(globalForeground);
        }

        // Apply text decorations
        if (style.Bold)
        {
            escapeSequence += "\u001b[1m";
        }

        if (style.Italic)
        {
            escapeSequence += "\u001b[3m";
        }

        if (style.Underline)
        {
            escapeSequence += "\u001b[4m";
        }

        return escapeSequence;
    }

    private string ConvertHexToAnsiForeground(string hex)
    {
        var colorCode = ConvertHexToAnsiColor(hex);
        return $"\u001b[38;5;{colorCode}m"; // 38;5;{color_code} for 256-color foreground
    }

    private string ConvertHexToAnsiBackground(string hex)
    {
        var colorCode = ConvertHexToAnsiColor(hex);
        return $"\u001b[48;5;{colorCode}m"; // 48;5;{color_code} for 256-color background
    }

    private int ConvertHexToAnsiColor(string hex)
    {
        // Parse the hex color
        int r = Convert.ToInt32(hex.Substring(1, 2), 16);
        int g = Convert.ToInt32(hex.Substring(3, 2), 16);
        int b = Convert.ToInt32(hex.Substring(5, 2), 16);

        // Map RGB values to the closest 256-color code
        return 16 + (36 * (r / 51)) + (6 * (g / 51)) + (b / 51);
    }
}
