using System.Text;
using SyntaxHighlighter.Styles;

namespace SyntaxHighlighter.Formatters;

public class HtmlFormatter : Formatter
{
    public override void Format(IEnumerable<Token> tokens, TextWriter writer, Style style)
    {
        writer.Write("<html><body><pre>");

        foreach (var token in tokens)
        {
            var tokenStyle = style.Get(token.Type);
            var htmlToken = BuildHtmlToken(token, tokenStyle);
            writer.Write(htmlToken);
        }

        writer.Write("</pre></body></html>");
    }

    private string BuildHtmlToken(Token token, TokenStyle style)
    {
        var styleAttributes = BuildStyleAttributes(style);
        return $"<span style=\"{styleAttributes}\">{System.Net.WebUtility.HtmlEncode(token.Value)}</span>";
    }

    private string BuildStyleAttributes(TokenStyle style)
    {
        var attributes = new StringBuilder();

        // Foreground (text color)
        if (!string.IsNullOrEmpty(style.Foreground))
            attributes.Append($"color: {style.Foreground}; ");

        // Background color
        if (!string.IsNullOrEmpty(style.Background))
            attributes.Append($"background-color: {style.Background}; ");

        // Border
        if (!string.IsNullOrEmpty(style.Border))
            attributes.Append($"border: 1px solid {style.Border}; ");

        // Text decorations
        if (style.Bold)
            attributes.Append("font-weight: bold; ");
        if (style.Italic)
            attributes.Append("font-style: italic; ");
        if (style.Underline)
            attributes.Append("text-decoration: underline; ");

        return attributes.ToString().Trim();
    }
}
