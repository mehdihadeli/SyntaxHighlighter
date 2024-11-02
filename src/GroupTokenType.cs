namespace SyntaxHighlighter;

public class GroupTokenType(IList<TokenType> tokenTypes) : ITokenTypeMatcher
{
    public IList<TokenType> TokenTypes { get; set; } = tokenTypes;

    public IEnumerable<Token> GetMatchedTokens(IList<string> regexMatchedGroups)
    {
        int tokenTypeIndex = 0;
        
        // Skip the first item (the entire match), and yield tokens for each group
        // First item typically represents the entire match, while the subsequent items represent each capturing group within that match.
        foreach (var group in regexMatchedGroups.Skip(1))
        {
            if (tokenTypeIndex >= TokenTypes.Count)
                break; // Stop if we have more groups than token types


            if (string.IsNullOrEmpty(group)) 
                continue;
            
            yield return new Token(TokenTypes[tokenTypeIndex], group);
            tokenTypeIndex++;
        }
    }
}
