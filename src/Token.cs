namespace SyntaxHighlighter;

public class Token(TokenType type, string value)
{
    public TokenType Type { get; } = type;
    public string Value { get; } = value;

    public override string ToString() => $"{Type}: {Value}";
}
