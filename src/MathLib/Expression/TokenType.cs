using System;

namespace MathLib.Expression
{
    [Flags]
    enum TokenType
    {
        None            = 0,
        Add             = 1 << 0,
        Subtract        = 1 << 1,
        Multiply        = 1 << 2,
        Divide          = 1 << 3,
        Power           = 1 << 4,
        Root            = 1 << 5,
        Modulo          = 1 << 6,
        Factorial       = 1 << 7,
        LeftBracket     = 1 << 8,
        RightBracket    = 1 << 9,
        Number          = 1 << 10,
        Pi              = 1 << 11,
        Euler           = 1 << 12
    }
}
