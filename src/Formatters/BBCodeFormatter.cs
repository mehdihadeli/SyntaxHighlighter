using SyntaxHighlighter.Styles;

namespace SyntaxHighlighter.Formatters;

public class BBCodeFormatter : Formatter
{
    public override void Format(IEnumerable<Token> tokens, TextWriter writer, Style style)
    {
        foreach (var token in tokens)
        {
            var tokenStyle = style.Get(token.Type);
            var bbCodeToken = BuildBBCodeToken(token, tokenStyle);
            writer.Write(bbCodeToken);
        }
    }

    private string BuildBBCodeToken(Token token, TokenStyle style)
    {
        var bbCode = new List<string>();

        // Start color tag if foreground color is specified
        if (!string.IsNullOrEmpty(style.Foreground))
            bbCode.Add($"[color={style.Foreground}]");

        // Start background color tag if background color is specified (BBCode does not support background color directly)
        // However, some forums or applications might allow custom tags like [background]
        if (!string.IsNullOrEmpty(style.Background))
            bbCode.Add($"[background={style.Background}]");

        // Bold, Italic, Underline
        if (style.Bold)
            bbCode.Add("[b]");
        if (style.Italic)
            bbCode.Add("[i]");
        if (style.Underline)
            bbCode.Add("[u]");

        // Add the token's text, ensuring any BBCode special characters in text are escaped
        bbCode.Add(EscapeBBCode(token.Value));

        // Close tags in reverse order
        if (style.Underline)
            bbCode.Add("[/u]");
        if (style.Italic)
            bbCode.Add("[/i]");
        if (style.Bold)
            bbCode.Add("[/b]");

        if (!string.IsNullOrEmpty(style.Background))
            bbCode.Add("[/background]");

        if (!string.IsNullOrEmpty(style.Foreground))
            bbCode.Add("[/color]");

        return string.Join("", bbCode);
    }

    private string EscapeBBCode(string text)
    {
        // Escaping special BBCode characters
        return text.Replace("[", "\\[").Replace("]", "\\]");
    }
}
