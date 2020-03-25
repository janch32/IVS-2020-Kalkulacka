using System;

namespace MathLib.Expression
{
    [Flags]
    enum TermType
    {
        AddSub = TokenType.Add | TokenType.Subtract,
        MulDivMod = TokenType.Multiply | TokenType.Divide | TokenType.Modulo,
        Factorial = TokenType.Factorial,
        PowRoot = TokenType.Power | TokenType.Root,
        LeftBracket = TokenType.LeftBracket,
        RightBracket = TokenType.RightBracket,
        Value = TokenType.Number | TokenType.Pi | TokenType.Euler,
        End = TokenType.None
    }
}
