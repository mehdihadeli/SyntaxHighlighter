using SyntaxHighlighter.Styles;

namespace SyntaxHighlighter.Formatters;

public abstract class Formatter {
    public abstract void Format(IEnumerable<Token> tokens, TextWriter writer,Style style);
}