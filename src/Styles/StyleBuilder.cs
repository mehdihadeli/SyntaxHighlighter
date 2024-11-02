namespace SyntaxHighlighter.Styles;

public class StyleBuilder(string name, Style parent)
{
    private readonly Dictionary<TokenType, TokenStyle> _entries = new();

    public StyleBuilder Add(TokenType type, TokenStyle entry)
    {
        _entries[type] = entry;
        return this;
    }

    public StyleBuilder SetParent(Style parentStyle)
    {
        parent = parentStyle;
        return this;
    }

    public Style Build()
    {
        var style = new Style { Name = name, Styles = new Dictionary<TokenType, TokenStyle>() };

        foreach (var entry in _entries)
        {
            var inheritedEntry = parent?.Get(entry.Key) ?? new TokenStyle();
            style.Styles[entry.Key] = entry.Value.Inherit(inheritedEntry);
        }

        return style;
    }
}