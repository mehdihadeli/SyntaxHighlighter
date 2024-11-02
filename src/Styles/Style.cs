using System.Reflection;
using System.Text.Json;

namespace SyntaxHighlighter.Styles;

public class Style
{
    public string? Name { get; set; }
    public string? Background { get; set; }
    public string? Foreground { get; set; }
    public int Margin { get; set; }
    public Dictionary<TokenType, TokenStyle> Styles { get; set; } = new();

    /// <summary>
    /// Load theme style by name
    /// </summary>
    /// <param name="themeName"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static async Task<Style> LoadFromJsonAsync(string themeName)
    {
        var name = $"{nameof(SyntaxHighlighter)}.{nameof(Styles)}.{themeName}";
        var assembly = Assembly.GetExecutingAssembly();

        await using var stream = assembly.GetManifestResourceStream(name);
        if (stream == null)
        {
            throw new FileNotFoundException($"Theme file '{themeName}' not found.");
        }

        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new TokenTypeDictionaryConverter()
            },
            WriteIndented = true, 
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };

        var style = await JsonSerializer.DeserializeAsync<Style>(stream, options) ?? new Style();

        return style;
    }

    public List<TokenType> Types()
    {
        List<TokenType> tokenTypes = new List<TokenType>();

        foreach (var tt in Styles.Keys)
        {
            tokenTypes.Add(tt);
        }

        return [.. tokenTypes];
    }
    
    public TokenStyle Get(TokenType type)
    {
        return Styles.TryGetValue(type, out var entry) ? entry : new TokenStyle();
    }
}