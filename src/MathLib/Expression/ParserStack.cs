using MathLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib.Expression
{
    class ParserStack
    {
        private MathLibrary Math = new MathLibrary();
        private List<object> stack = new List<object>();

        private Token GetLastToken()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
                if (stack[i] is Token token) return token;

            throw new ParseException(
                "Cannot get last token from parser stack. " +
                "Stack does not contain any Token");
        }

        public double GetFirstValue()
        {
            foreach (var item in stack)
                if (item is double value) return value;

            throw new ParseException(
                "Cannot get value from parser stack");
        }

        public void Push(Token token)
        {
            stack.Add(token);
        }

        public void Push(Precedence precedence)
        {
            switch (precedence)
            {
                case Precedence.Equals:
                case Precedence.Left:
                    Evaluate();
                    break;
                case Precedence.Right:
                    stack.Insert(
                        stack.LastIndexOf(GetLastToken()) + 1, 
                        precedence);
                    break;
                default:
                    throw new ParseException("Invalid precedence type");
            }
        }

        private double Evaluate()
        {
            var val = new List<double>();
            Token op = null;

            for (int i = stack.Count - 1; i >= 0; i--)
            {
                if (stack[i] is Precedence precedence) break;
                else if (stack[i] is double value) val.Add(value);
                else if (stack[i] is Token token) op = token;
                else throw new ParseException(
                    $"Unknown item in parser stack \"{stack[i]}\"");
            }

            switch (op?.Type ?? TokenType.None)
            {
                case TokenType.Add:
                    return Math.Add(val[1], val[0]);
                case TokenType.Subtract:
                    return Math.Sub(val[1], val[0]);
                case TokenType.Multiply:
                    return Math.Mul(val[1], val[0]);
                case TokenType.Divide:
                    return Math.Div(val[1], val[0]);
                case TokenType.Power:
                    return Math.Power(val[1], val[0]);
                case TokenType.Root:
                    return Math.Root(val[1], val[0]);
                case TokenType.Modulo:
                    return Math.Modulo(val[1], val[0]);
                case TokenType.Factorial:
                    return Math.Factorial(val[0]);
                case TokenType.LeftBracket:
                    return val[0];
                case TokenType.Number:
                    return double.Parse(op.Value);
                case TokenType.Pi:
                    return Math.PI;
                case TokenType.Euler:
                    return Math.E;
            }
        }
    }
}
