using SyntaxHighlighter.Utills;

namespace SyntaxHighlighter.Lexers;

public class GoLexer : Lexer
{
    protected override List<Rule> Rules =>
        [
            new(@"\s*(\r\n|\n)", TokenType.LineBreak), // Matches empty lines
            new(@"\s*\n", TokenType.LineBreak), // Matches empty lines with any whitespace
            new(@"\r\n", TokenType.LineBreak), // Windows-style newline "\r\n"
            new(@"\s+", TokenType.Text), // Any whitespace within lines
            new(@"\\\n", TokenType.LineBreak), // Line continuations (backslash and newline)
            new(@"//[^\n\r]*", TokenType.CommentSingle), // Single-line comments
            new(@"/(\*\*|.*?)(\*)/", TokenType.CommentMultiline), // Multiline comments
            new(@"\b(import|package)\b", TokenType.KeywordNamespace), // Namespace keywords
            // Declaration keywords
            new(
                $@"\b{LexerUtils.Words("var", "func", "struct", "map", "chan", "type", "interface", "const")}\b",
                TokenType.KeywordDeclaration
            ),
            // Control flow keywords

            new(
                $@"\b{LexerUtils.Words("break", "default", "select", "case", "defer", "go", "else", "goto", "switch", "fallthrough", "if", "range", "continue", "for", "return")}\b",
                TokenType.Keyword
            ),
            // Go constants

            new(
                $@"\b{LexerUtils.Words("true", "false", "iota", "nil")}\b",
                TokenType.KeywordConstant
            ),
            // Built-in types/functions
            new(
                $@"\b{LexerUtils.Words("uint", "int", "float", "string", "bool", "error", "uintptr", "print", "println")}\b",
                TokenType.NameBuiltin
            ),
            // Common type keywords

            new Rule(
                $@"\b{LexerUtils.Words("uint", "int", "float", "string", "bool", "error", "uintptr")}\b",
                TokenType.Keyword
            ),
            // Number literals

            new(@"\d+\.\d*([eE][-+]?\d+)?i?", TokenType.LiteralNumberFloat), // Floating-point literals
            new(@"0[0-7]+", TokenType.LiteralNumberOct), // Octal numbers
            new(@"0[xX][0-9a-fA-F_]+", TokenType.LiteralNumberHex), // Hexadecimal numbers
            new(@"0b[01_]+", TokenType.LiteralNumberBin), // Binary numbers
            new(@"\d+", TokenType.LiteralNumberInteger), // Decimal integers
            // String and character literals
            new(@"'([^\\]|\\.)'", TokenType.LiteralStringChar), // Single-character literals
            new(@"`[^`]*`", TokenType.LiteralString), // Raw string literals
            new(@"""[^""]*""", TokenType.LiteralString), // Standard string literals
            // Operators
            new(
                @"(<<=|>>=|<<|>>|<=|>=|&\^=|\+=|-=|\*=|/=|%=|&=|\|=|&&|\|\||<-|\+\+|--|==|!=|:=|\.\.\.|[+\-*/%&])",
                TokenType.Operator
            ),
            // Function calls like `SetContent(`

            new Rule(
                @"([a-zA-Z_][a-zA-Z0-9_]*)\s*(\()",
                [TokenType.NameFunction, TokenType.Punctuation]
            ),
            // Variable names and identifiers

            new(@"[^\W\d]\w*", TokenType.NameOther),
            // Punctuation
            new(@"[|^<>=!()\[\]{}.,;:~]", TokenType.Punctuation),
            // Code block markers
            new(@"```([a-zA-Z0-9]+)?", TokenType.CodeBlockStart), // Code block start with optional language identifier
            new(@"```", TokenType.CodeBlockEnd),
        ];
}
