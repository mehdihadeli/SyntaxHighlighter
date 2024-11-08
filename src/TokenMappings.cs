namespace SyntaxHighlighter;

public static class TokenMappings
{
    public static readonly Dictionary<TokenType, string> StandardTypes =
        new()
        {
            { TokenType.Background, "bg" },
            { TokenType.Line, "line" },
            { TokenType.LineNumbers, "ln" },
            { TokenType.LineNumbersTable, "lnt" },
            { TokenType.LineHighlight, "hl" },
            { TokenType.LineTable, "lntable" },
            { TokenType.LineTableTD, "lntd" },
            { TokenType.LineLink, "lnlinks" },
            { TokenType.CodeLine, "cl" },
            { TokenType.Text, "" },
            { TokenType.TextWhitespace, "w" },
            { TokenType.Error, "err" },
            { TokenType.Other, "x" },
            // Keywords
            { TokenType.Keyword, "k" },
            { TokenType.KeywordConstant, "kc" },
            { TokenType.KeywordDeclaration, "kd" },
            { TokenType.KeywordNamespace, "kn" },
            { TokenType.KeywordPseudo, "kp" },
            { TokenType.KeywordReserved, "kr" },
            { TokenType.KeywordType, "kt" },
            // Names
            { TokenType.Name, "n" },
            { TokenType.NameAttribute, "na" },
            { TokenType.NameBuiltin, "nb" },
            { TokenType.NameBuiltinPseudo, "bp" },
            { TokenType.NameClass, "nc" },
            { TokenType.NameConstant, "no" },
            { TokenType.NameDecorator, "nd" },
            { TokenType.NameEntity, "ni" },
            { TokenType.NameException, "ne" },
            { TokenType.NameFunction, "nf" },
            { TokenType.NameFunctionMagic, "fm" },
            { TokenType.NameProperty, "py" },
            { TokenType.NameLabel, "nl" },
            { TokenType.NameNamespace, "nn" },
            { TokenType.NameOther, "nx" },
            { TokenType.NameTag, "nt" },
            { TokenType.NameVariable, "nv" },
            { TokenType.NameVariableClass, "vc" },
            { TokenType.NameVariableGlobal, "vg" },
            { TokenType.NameVariableInstance, "vi" },
            { TokenType.NameVariableMagic, "vm" },
            // Literals
            { TokenType.Literal, "l" },
            { TokenType.LiteralDate, "ld" },
            // Strings
            { TokenType.LiteralString, "s" },
            { TokenType.LiteralStringAffix, "sa" },
            { TokenType.LiteralStringBacktick, "sb" },
            { TokenType.LiteralStringChar, "sc" },
            { TokenType.LiteralStringDelimiter, "dl" },
            { TokenType.LiteralStringDoc, "sd" },
            { TokenType.LiteralStringDouble, "s2" },
            { TokenType.LiteralStringEscape, "se" },
            { TokenType.LiteralStringHeredoc, "sh" },
            { TokenType.LiteralStringInterpol, "si" },
            { TokenType.LiteralStringOther, "sx" },
            { TokenType.LiteralStringRegex, "sr" },
            { TokenType.LiteralStringSingle, "s1" },
            { TokenType.LiteralStringSymbol, "ss" },
            // Numbers
            { TokenType.LiteralNumber, "m" },
            { TokenType.LiteralNumberBin, "mb" },
            { TokenType.LiteralNumberFloat, "mf" },
            { TokenType.LiteralNumberHex, "mh" },
            { TokenType.LiteralNumberInteger, "mi" },
            { TokenType.LiteralNumberIntegerLong, "il" },
            { TokenType.LiteralNumberOct, "mo" },
            // Operators
            { TokenType.Operator, "o" },
            { TokenType.OperatorWord, "ow" },
            // Punctuation
            { TokenType.Punctuation, "p" },
            // Comments
            { TokenType.Comment, "c" },
            { TokenType.CommentHashbang, "ch" },
            { TokenType.CommentMultiline, "cm" },
            { TokenType.CommentPreproc, "cp" },
            { TokenType.CommentPreprocFile, "cpf" },
            { TokenType.CommentSingle, "c1" },
            { TokenType.CommentSpecial, "cs" },
            // Generic tokens
            { TokenType.Generic, "g" },
            { TokenType.GenericDeleted, "gd" },
            { TokenType.GenericEmph, "ge" },
            { TokenType.GenericError, "gr" },
            { TokenType.GenericHeading, "gh" },
            { TokenType.GenericInserted, "gi" },
            { TokenType.GenericOutput, "go" },
            { TokenType.GenericPrompt, "gp" },
            { TokenType.GenericStrong, "gs" },
            { TokenType.GenericSubheading, "gu" },
            { TokenType.GenericTraceback, "gt" },
            { TokenType.GenericUnderline, "gl" },
        };
}
