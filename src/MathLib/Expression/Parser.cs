using MathLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib.Expression
{
    class Parser
    {
        private Precedence GetTermPrecedence(TermType curr, TermType prev)
        {
            switch (prev)
            {
                case TermType.AddSub:
                    return (curr & (TermType.AddSub | TermType.RightBracket | TermType.End)) > 0
                        ? Precedence.Left : Precedence.Right;
                case TermType.MulDivMod:
                    return (curr & (TermType.Factorial | TermType.PowRoot | TermType.LeftBracket | TermType.Value)) > 0
                        ? Precedence.Right : Precedence.Left;
                case TermType.Factorial:
                    return (curr & (TermType.LeftBracket | TermType.Value)) > 0
                        ? Precedence.None : Precedence.Left;
                case TermType.PowRoot:
                    return (curr & (TermType.Factorial | TermType.LeftBracket | TermType.Value)) > 0
                        ? Precedence.Right : Precedence.Left;
                case TermType.LeftBracket:
                    if(curr == TermType.RightBracket) return Precedence.Equals;
                    if(curr == TermType.End) return Precedence.None;
                    return Precedence.Right;
                case TermType.Value:
                    return (curr & (TermType.LeftBracket | TermType.Value)) > 0
                        ? Precedence.None : Precedence.Left;
                case TermType.End:
                    return (curr & (TermType.RightBracket | TermType.End)) > 0
                    ? Precedence.None : Precedence.Right;
            }

            return Precedence.None;
        }
    }
}
