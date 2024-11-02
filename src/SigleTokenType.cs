namespace SyntaxHighlighter;

public class SingleTokenType(TokenType tokenType) : ITokenTypeMatcher
{
    public TokenType TokenType { get; set; } = tokenType;

    public IEnumerable<Token> GetMatchedTokens(IList<string> regexMatchedGroups)
    {
        var match = regexMatchedGroups.FirstOrDefault();
        
        return match != null ? new[] { new Token(TokenType, match) } : Enumerable.Empty<Token>();
    }

    public static implicit operator SingleTokenType(TokenType tokenType) => new(tokenType);
}
