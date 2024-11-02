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
    /// Load an existing builtin theme style by name
    /// </summary>
    /// <param name="themeName"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static async Task<Style> LoadThemeByName(string themeName)
    {
        var name = $"{nameof(SyntaxHighlighter)}.{nameof(Styles)}.{themeName}.json";
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
    
    /// <summary>
    /// Load a custom theme through an embedded json theme by its fully resource name.
    /// </summary>
    /// <param name="fullResourceName">json theme full resource name as an embedded resource file.</param>
    /// <param name="resourceAssembly"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static async Task<Style> LoadExternalThemeByResourceName(string fullResourceName, Assembly resourceAssembly)
    {
        await using var stream = resourceAssembly.GetManifestResourceStream(fullResourceName);
        if (stream == null)
        {
            throw new FileNotFoundException($"Theme file '{fullResourceName}' not found.");
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