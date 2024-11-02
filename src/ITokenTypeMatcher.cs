namespace SyntaxHighlighter;

public interface ITokenTypeMatcher
{
    public IEnumerable<Token> GetMatchedTokens(IList<string> regexMatchedGroups);
}
