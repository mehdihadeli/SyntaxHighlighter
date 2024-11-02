using System.Text.RegularExpressions;

namespace SyntaxHighlighter.Utills;

public static class LexerUtils
{
    /// <summary>
    /// Generates a regex pattern that matches any of the provided words, optionally followed by a suffix.
    /// </summary>
    public static string Words(params string[] words)
    {
        // Sort words by length in descending order
        var sortedWords = words.OrderByDescending(word => word.Length).ToArray();

        // Quote each word to escape special characters
        for (int i = 0; i < sortedWords.Length; i++)
        {
            sortedWords[i] = Regex.Escape(sortedWords[i]);
        }

        // Join words with | (OR) operator and wrap with parentheses
        return $"({string.Join("|", sortedWords)})";
    }

    /// <summary>
    /// Matches groups in the input string based on the pattern, returning tokens with specified types for each group.
    /// </summary>
    public static IEnumerable<Token> TokenizeByGroups(
        string pattern,
        string input,
        TokenType[] types,
        RegexOptions options = RegexOptions.None
    )
    {
        var matches = Regex.Matches(input, pattern, options);
        foreach (Match match in matches)
        {
            for (int i = 1; i < match.Groups.Count; i++)
            {
                yield return new Token(types[i - 1], match.Groups[i].Value);
            }
        }
    }

    /// <summary>
    /// A method for creating token groups, similar to Pygments' bygroups function.
    /// This method returns tokens based on group matches in a regex pattern.
    /// </summary>
    public static IEnumerable<Token> ByGroups(
        string pattern,
        string input,
        params TokenType[] tokenTypes
    )
    {
        var regex = new Regex(pattern);
        var match = regex.Match(input);

        if (!match.Success)
            yield break;

        for (int i = 1; i < match.Groups.Count; i++)
        {
            yield return new Token(tokenTypes[i - 1], match.Groups[i].Value);
        }
    }

    public static ITokenTypeMatcher ToGroupTypeMatcher(params TokenType[] tokenTypes)
    {
        return new GroupTokenType(tokenTypes);
    }

    public static ITokenTypeMatcher ToTypeMatcher(this TokenType tokenType)
    {
        return new SingleTokenType(tokenType);
    }

    /// <summary>
    /// Matches patterns with case-insensitive option for keywords.
    /// </summary>
    public static string CaseInsensitiveWords(IEnumerable<string> words, string suffix = "")
    {
        return @"(?i:\b(" + string.Join("|", words) + @")\b)" + suffix;
    }

    /// <summary>
    /// Handles pattern matching with specified regex options like case-insensitivity.
    /// </summary>
    public static IEnumerable<Token> TokenizeWithOptions(
        string pattern,
        string input,
        TokenType type,
        RegexOptions options = RegexOptions.None
    )
    {
        var regex = new Regex(pattern, options);
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            yield return new Token(type, match.Value);
        }
    }

    /// <summary>
    /// Matches a pattern with multiple groups in a case-insensitive manner.
    /// </summary>
    public static IEnumerable<Token> CaseInsensitiveByGroups(
        string pattern,
        string input,
        params TokenType[] tokenTypes
    )
    {
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        var match = regex.Match(input);

        if (!match.Success)
            yield break;

        for (int i = 1; i < match.Groups.Count; i++)
        {
            yield return new Token(tokenTypes[i - 1], match.Groups[i].Value);
        }
    }
}
