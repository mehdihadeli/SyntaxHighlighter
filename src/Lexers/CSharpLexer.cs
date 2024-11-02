using SyntaxHighlighter.Utills;

namespace SyntaxHighlighter.Lexers;

public class CSharpLexer : Lexer
{
    protected override List<Rule> Rules =>
        [
            new Rule(@"\s*(\r\n|\n)", TokenType.LineBreak),
            // Matches empty lines with any whitespace
            new Rule(@"\s*\n", TokenType.LineBreak),
            // Matches Windows-style newline "\r\n"
            new Rule(@"\r\n", TokenType.LineBreak),
            // Any whitespace within lines
            new Rule(@"\s+", TokenType.Text),
            // Line continuations (backslash and newline)
            new Rule(@"\\\n", TokenType.LineBreak),
            // Single-line comments
            new Rule(@"//[^\n\r]*", TokenType.CommentSingle),
            // Multiline comments
            new Rule(@"/\*.*?\*/", TokenType.CommentMultiline),
            // Namespace and using directives
            new Rule(@"\b(namespace|using)\b", TokenType.KeywordNamespace),
            // Declaration keywords (variables, methods, etc.)
            new Rule(
                $@"\b{LexerUtils.Words("class", "struct", "interface", "enum", "record", "delegate", "event")}\b",
                TokenType.KeywordDeclaration
            ),
            // Control flow keywords

            new Rule(
                $@"\b{LexerUtils.Words("if", "else", "switch", "case", "default", "for", "foreach", "while", "do", "break", "continue", "return", "throw", "try", "catch", "finally", "lock", "goto", "using", "yield")}\b",
                TokenType.Keyword
            ),
            // Type keywords

            new Rule(
                $@"\b{LexerUtils.Words("int", "uint", "short", "ushort", "long", "ulong", "byte", "sbyte", "float", "double", "decimal", "bool", "char", "string", "object", "dynamic", "void")}\b",
                TokenType.KeywordType
            ),
            // Constants

            new Rule($@"\b(true|false|null)\b", TokenType.KeywordConstant),
            // Built-in types
            new Rule(
                $@"\b(Console|Math|String|DateTime|List|Dictionary|HashSet|Tuple|Task|Action|Func|EventHandler|Exception)\b",
                TokenType.NameBuiltin
            ),
            // Number literals

            new Rule(@"\d+\.\d*([eE][-+]?\d+)?", TokenType.LiteralNumberFloat), // Floating-point numbers
            new Rule(@"0[xX][0-9a-fA-F_]+", TokenType.LiteralNumberHex), // Hexadecimal numbers
            new Rule(@"\d+", TokenType.LiteralNumberInteger), // Integer literals
            // String and character literals
            new Rule(@"'([^\\]|\\.)'", TokenType.LiteralStringChar), // Single-character literals
            new Rule(@"""[^""]*""", TokenType.LiteralString), // Standard string literals
            // Operators
            new Rule(
                @"(\+\+|--|\+=|-=|\*=|/=|%=|&=|\|=|\^=|<<=|>>=|==|!=|<=|>=|&&|\|\||[+\-*/%&|^~!=<>?=<>])",
                TokenType.Operator
            ),
            // Function calls

            new Rule(
                @"([a-zA-Z_][a-zA-Z0-9_]*)\s*(\()",
                new[] { TokenType.NameFunction, TokenType.Punctuation }
            ),
            // Variable names and identifiers

            new Rule(@"[^\W\d]\w*", TokenType.NameOther),
            // Punctuation
            new Rule(@"[{}()\[\];,.:]", TokenType.Punctuation),
            // Code block markers
            new Rule(@"```([a-zA-Z0-9]+)?", TokenType.CodeBlockStart), // Code block start with optional language identifier
            new Rule(@"```", TokenType.CodeBlockEnd),
        ];
}
