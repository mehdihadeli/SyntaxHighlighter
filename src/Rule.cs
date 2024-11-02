namespace SyntaxHighlighter;

public class Rule(string pattern, ITokenTypeMatcher tokenTypeMatcher, bool matchFromStart = true)
{
    public Rule(string pattern, TokenType tokenType, bool matchFromStart = true)
        : this(pattern, TokenMatcherFactory.CreateMatcher(tokenType), matchFromStart) { }

    public Rule(string pattern, IList<TokenType> tokenTypes, bool matchFromStart = true)
        : this(pattern, TokenMatcherFactory.CreateMatcher(tokenTypes.ToArray()), matchFromStart) { }

    public string Pattern { get; } = pattern;
    public ITokenTypeMatcher TokenTypeMatcher { get; } = tokenTypeMatcher;
    public bool MatchFromStart { get; } = matchFromStart;
}

public static class TokenMatcherFactory
{
    public static ITokenTypeMatcher CreateMatcher(params TokenType[] tokenTypes)
    {
        return tokenTypes.Length switch
        {
            1 => new SingleTokenType(tokenTypes[0]),
            _ => new GroupTokenType(tokenTypes),
        };
    }
}
