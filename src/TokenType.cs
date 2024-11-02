namespace SyntaxHighlighter;

public enum TokenType
{
    // Meta token types
    Background = -1,
    PreWrapper = -2,
    Line = -3,
    LineNumbers = -4,
    LineNumbersTable = -5,
    LineHighlight = -6,
    LineTable = -7,
    LineTableTD = -8,
    LineLink = -9,
    CodeLine = -10,
    Error = -11,
    Other = -12,
    None = -13,
    Ignore = -14,
    CodeBlockStart = 15,
    CodeBlockEnd = 16,
    LineBreak = 17,
    UnMatched = 18,
    EOFType = 0,

    // Keywords
    Keyword = 1000,
    KeywordConstant,
    KeywordDeclaration,
    KeywordNamespace,
    KeywordPseudo,
    KeywordReserved,
    KeywordType,

    // Names
    Name = 2000,
    NameAttribute,
    NameBuiltin,
    NameBuiltinPseudo,
    NameClass,
    NameConstant,
    NameDecorator,
    NameEntity,
    NameException,
    NameFunction,
    NameFunctionMagic,
    NameKeyword,
    NameLabel,
    NameNamespace,
    NameOperator,
    NameOther,
    NamePseudo,
    NameProperty,
    NameTag,
    NameVariable,
    NameVariableAnonymous,
    NameVariableClass,
    NameVariableGlobal,
    NameVariableInstance,
    NameVariableMagic,

    // Literals
    Literal = 3000,
    LiteralDate,
    LiteralOther,

    // Strings
    LiteralString = 3100,
    LiteralStringAffix,
    LiteralStringAtom,
    LiteralStringBacktick,
    LiteralStringBoolean,
    LiteralStringChar,
    LiteralStringDelimiter,
    LiteralStringDoc,
    LiteralStringDouble,
    LiteralStringEscape,
    LiteralStringHeredoc,
    LiteralStringInterpol,
    LiteralStringName,
    LiteralStringOther,
    LiteralStringRegex,
    LiteralStringSingle,
    LiteralStringSymbol,

    // Numbers
    LiteralNumber = 3200,
    LiteralNumberBin,
    LiteralNumberFloat,
    LiteralNumberHex,
    LiteralNumberInteger,
    LiteralNumberIntegerLong,
    LiteralNumberOct,
    LiteralNumberByte,

    // Operators
    Operator = 4000,
    OperatorWord,

    // Punctuation
    Punctuation = 5000,

    // Comments
    Comment = 6000,
    CommentHashbang,
    CommentMultiline,
    CommentSingle,
    CommentSpecial,

    // Preprocessor Comments
    CommentPreproc = 6100,
    CommentPreprocFile,

    // Generic tokens
    Generic = 7000,
    GenericDeleted,
    GenericEmph,
    GenericError,
    GenericHeading,
    GenericInserted,
    GenericOutput,
    GenericPrompt,
    GenericStrong,
    GenericSubheading,
    GenericTraceback,
    GenericUnderline,

    // Text
    Text = 8000,
    TextWhitespace,
    TextSymbol,
    TextPunctuation,
}
