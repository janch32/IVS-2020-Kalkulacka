using MathLib.Exceptions;
using System.Collections.Generic;
using System.Globalization;

namespace MathLib.Expression
{
    internal class ParserStack
    {
        private readonly MathLibrary Math = new MathLibrary();

        // Jo, dal jsem tam object, zažaluj mě
        //
        // Ale kdyby byla jiná cesta jak do listu narvat Token, decimal a Enum,
        // tak bych to rád zkrášlil. Zatím jsem ale na nic jiného nepřišel.
        private readonly List<object> Stack = new List<object>();

        public bool Empty
        {
            get => Stack.Count == 0 || LastToken().Type == TokenType.None;
        }

        public Token LastToken()
        {
            for (int i = Stack.Count - 1; i >= 0; i--)
                if (Stack[i] is Token token) return token;

            throw new ParseException(
                "Cannot get last token from parser stack. " +
                "Stack does not contain any Token");
        }

        public decimal FirstValue()
        {
            foreach (var item in Stack)
                if (item is decimal value) return value;

            throw new ParseException(
                "Cannot get value from parser stack");
        }

        public void Push(Token token)
        {
            Stack.Add(token);
        }

        public void Push(Precedence precedence)
        {
            switch (precedence)
            {
                case Precedence.Equals:
                case Precedence.Left:
                    Stack.Add(Evaluate());
                    break;
                case Precedence.Right:
                    Stack.Insert(
                        Stack.LastIndexOf(LastToken()) + 1, 
                        precedence);
                    break;
                default:
                    throw new ParseException("Invalid precedence type");
            }
        }

        private decimal Evaluate()
        {
            var val = new List<decimal>();
            Token op = null;

            for (int i = Stack.Count - 1; i >= 0; i--)
            {
                if (Stack[i] is Precedence)
                {
                    Stack.RemoveAt(i);
                    break;
                }

                if (Stack[i] is decimal value) val.Add(value);
                else if (Stack[i] is Token token) op = token;
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
