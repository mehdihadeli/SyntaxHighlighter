using System.Text.RegularExpressions;

namespace SyntaxHighlighter.Lexers;

public abstract class Lexer
{
    protected abstract List<Rule> Rules { get; }

    public virtual IEnumerable<Token> Tokenize(string sourceCode)
    {
        int position = 0;

        while (position < sourceCode.Length)
        {
            bool matched = false;

            // Code block detection
            if (sourceCode.Substring(position).StartsWith("```") && position == 0)
            {
                position += 3;
                int languageEnd = sourceCode.IndexOf('\n', position);
                if (languageEnd > position)
                {
                    string languageIdentifier = sourceCode
                        .Substring(position, languageEnd - position)
                        .Trim();
                    position = languageEnd;
                    yield return new Token(TokenType.CodeBlockStart, languageIdentifier);
                }
                else
                {
                    yield return new Token(TokenType.CodeBlockStart, "");
                }

                matched = true;
            }
            else if (sourceCode.Substring(position).StartsWith("```"))
            {
                position += 3;
                yield return new Token(TokenType.CodeBlockEnd, "");
                matched = true;
            }
            else
            {
                foreach (var rule in Rules)
                {
                    string pattern = rule.MatchFromStart ? $"^{rule.Pattern}" : rule.Pattern;
                    var regex = new Regex(pattern, RegexOptions.Compiled);
                    var regexMatch = regex.Match(sourceCode.Substring(position));

                    if (regexMatch.Success)
                    {
                        var tokens = rule.TokenTypeMatcher.GetMatchedTokens(
                            regexMatch.Groups.Values.Select(g => g.Value).ToList()
                        );

                        foreach (var token in tokens)
                        {
                            yield return token;
                        }

                        position += regexMatch.Length;
                        matched = true;
                        break;
                    }
                }
            }

            if (!matched)
            {
                position++;
            }
        }
    }
}
