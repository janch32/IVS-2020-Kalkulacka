using MathLib.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MathLib.Expression
{
    class Scanner
    {
        private readonly Regex Add = new Regex(@"^\s*\+");
        private readonly Regex Subtract = new Regex(@"^\s*-");
        private readonly Regex Multiply = new Regex(@"^\s*\*");
        private readonly Regex Divide = new Regex(@"^\s*\/");
        private readonly Regex Power = new Regex(@"^\s*(pow|\^)", RegexOptions.IgnoreCase);
        private readonly Regex Root = new Regex(@"^\s*root", RegexOptions.IgnoreCase);
        private readonly Regex Modulo = new Regex(@"^\s*(mod|%)", RegexOptions.IgnoreCase);
        private readonly Regex Factorial = new Regex(@"^\s*!");
        private readonly Regex LeftBracket = new Regex(@"^\s*\(");
        private readonly Regex RightBracket = new Regex(@"^\s*\)");
        private readonly Regex Number = new Regex(@"^\s*-?([1-9]\d*|0)((\.|,)\d+)?");
        private readonly Regex Pi = new Regex(@"^\s*(pi|π)", RegexOptions.IgnoreCase);
        private readonly Regex Euler = new Regex(@"^\s*(e|euler)", RegexOptions.IgnoreCase);

        public Token GetToken(string expr)
        {
            Match match;

            if ((match = Add.Match(expr)).Success)
                return new Token(TokenType.Add, match.Value.Trim());

            if ((match = Subtract.Match(expr)).Success)
                return new Token(TokenType.Subtract, match.Value.Trim());

            if ((match = Multiply.Match(expr)).Success)
                return new Token(TokenType.Multiply, match.Value.Trim());

            if ((match = Divide.Match(expr)).Success)
                return new Token(TokenType.Divide, match.Value.Trim());

            if ((match = Power.Match(expr)).Success)
                return new Token(TokenType.Power, match.Value.Trim());

            if ((match = Root.Match(expr)).Success)
                return new Token(TokenType.Root, match.Value.Trim());

            if ((match = Modulo.Match(expr)).Success)
                return new Token(TokenType.Modulo, match.Value.Trim());

            if ((match = Factorial.Match(expr)).Success)
                return new Token(TokenType.Factorial, match.Value.Trim());

            if ((match = LeftBracket.Match(expr)).Success)
                return new Token(TokenType.LeftBracket, match.Value.Trim());

            if ((match = RightBracket.Match(expr)).Success)
                return new Token(TokenType.RightBracket, match.Value.Trim());

            if ((match = Number.Match(expr)).Success)
                return new Token(TokenType.Number, match.Value.Trim());

            if ((match = Pi.Match(expr)).Success)
                return new Token(TokenType.Pi, match.Value.Trim());

            if ((match = Euler.Match(expr)).Success)
                return new Token(TokenType.Euler, match.Value.Trim());

            throw new ParseException(
                $"Unknown token \"{expr}\"");
        }

        public Token[] GetTokens(string expr)
        {
            expr = expr.Trim();

            var tokens = new List<Token>();
            int pos = 0;
            try
            {
                while (!string.IsNullOrEmpty(expr))
                {
                    var token = GetToken(expr);
                    var len = expr.IndexOf(token.Value) + token.Value.Length;
                    token.Position = pos;
                    pos += len;
                    expr = expr.Substring(len);
                    tokens.Add(token);
                }
            }
            catch (ParseException e)
            {
                throw new ParseException(
                    $"Syntax Error: {e.Message} on pos {pos}");
            }

            return tokens.ToArray();
        }
    }
}
