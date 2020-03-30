using MathLib.Exceptions;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace MathLib.Expression
{
    /// <summary>
    /// Stack implementation for precedence climbing evaluation method.
    /// This method is fully described in 8th presentation of the IFJ course (year 2020)
    /// </summary>
    internal class ParserStack
    {
        private readonly MathLibrary Math = new MathLibrary();
        private readonly List<ParserStackItem> Stack = new List<ParserStackItem>();

        /// <summary>
        /// Returns true if stack is completely empty or contains only "stop" token
        /// </summary>
        public bool Empty
        {
            get => Stack.Count == 0 || LastToken().Type == TokenType.None;
        }

        /// <summary>
        /// Returns topmost token from the stack
        /// </summary>
        /// <exception cref="ParseException">Throws when the stack does not contain any token</exception>
        /// <returns>Last (topmost) token from the stack</returns>
        public Token LastToken()
        {
            for (int i = Stack.Count - 1; i >= 0; i--)
                if (Stack[i].Token != null) return Stack[i].Token;

            throw new ParseException(
                "Cannot get last token from parser stack. " +
                "Stack does not contain any Token");
        }

        /// <summary>
        /// Return first calculated value from stack
        /// </summary>
        /// <exception cref="ParseException">Throws when the stack does not contain any value</exception>
        /// <returns>First (bottom) value in the stack</returns>
        public decimal FirstValue()
        {
            foreach (var item in Stack)
                if (item.Value != null) return (decimal)item.Value;

            throw new ParseException(
                "Cannot get value from parser stack");
        }

        /// <summary>
        /// Pushes token to the end of the stack
        /// </summary>
        /// <param name="token">Token pushed onto the stack</param>
        public void Push(Token token)
        {
            Stack.Add(new ParserStackItem(token));
        }

        /// <summary>
        /// If <see cref="Precedence.Left"/> or <see cref="Precedence.Equals"/> is pushed, current 
        /// stack will be evaluated and the result of this will be pushed to the stack.
        /// Otherwise precedence sign will be placed in the stack after the topmost token
        /// </summary>
        /// <exception cref="ParseException">Throws when <see cref="Precedence.None"/> is passed in argument</exception>
        /// <param name="precedence">Precedence value to be pushed on stack</param>
        public void Push(Precedence precedence)
        {
            switch (precedence)
            {
                case Precedence.Equals:
                case Precedence.Left:
                    Stack.Add(new ParserStackItem(Evaluate()));
                    break;
                case Precedence.Right:
                    Stack.Insert(
                        Stack.FindLastIndex(e => e.Token == LastToken()) + 1, 
                        new ParserStackItem(precedence));
                    break;
                default:
                    throw new ParseException("Invalid precedence type");
            }
        }

        /// <summary>
        /// Evaluates part of stack from the top to first occurence of <see cref="Precedence.Right"/>.
        /// This method uses methods provided by <see cref="MathLibrary"/>
        /// </summary>
        /// <exception cref="ParseException">Throws when the stack is malformed</exception>
        /// <exception cref="DivideByZeroException">Throws when division by zero occurs when evaluating expression</exception>
        /// <exception cref="ArithmeticException">Throws when invalid argument occurs in math function</exception>
        /// <returns>Numerical result of the evaluation</returns>
        private decimal Evaluate()
        {
            var val = new List<decimal>();
            Token op = null;

            for (int i = Stack.Count - 1; i >= 0; i--)
            {
                if (Stack[i].Precedence != null)
                {
                    Stack.RemoveAt(i);
                    break;
                }

                if (Stack[i].Value != null) val.Add((decimal)Stack[i].Value);
                else if (Stack[i].Token != null) op = Stack[i].Token;
                else throw new ParseException(
                    $"Unknown item in parser stack \"{Stack[i]}\"");

                Stack.RemoveAt(i);
            }

            if (op == null) throw new ParseException(
                "Cannot evaulate stack. No operand in expression");

            if(val.Count == 2)
            {
                switch (op.Type)
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
                }
            }
            else if (val.Count == 1)
            {
                switch (op.Type)
                {
                    case TokenType.Factorial:
                        return Math.Factorial(val[0]);
                    case TokenType.LeftBracket:
                        return val[0];
                }
            }
            else
            {
                switch (op.Type)
                {
                    case TokenType.Number:
                        return decimal.Parse(op.Value, CultureInfo.InvariantCulture);
                    case TokenType.Pi:
                        if (op.Value.Contains("-")) return -Math.PI;
                        return Math.PI;
                    case TokenType.Euler:
                        if (op.Value.Contains("-")) return -Math.E;
                        return Math.E;
                }
            }

            throw new ParseException(
                "Cannot evaulate stack. Wrong number of arguments or unknown operand");
        }
    }
}
