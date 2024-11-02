namespace SyntaxHighlighter.Styles;

public class TokenStyle
{
    public string? Foreground { get; set; }
    public string? Background { get; set; }
    public string? Border { get; set; }

    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public bool NoInherit { get; set; }

    public TokenStyle Inherit(TokenStyle ancestor)
    {
        if (NoInherit)
            return this;

        return new TokenStyle
        {
            Foreground = Foreground ?? ancestor.Foreground,
            Background = Background ?? ancestor.Background,
            Border = Border ?? ancestor.Border,
            Bold = ancestor.Bold,
            Italic = ancestor.Italic,
            Underline = ancestor.Underline,
            NoInherit = NoInherit,
        };
    }
}