using MathLib.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MathLib.Expression
{
    internal class Scanner
    {
        private readonly Regex Add = new Regex(@"^\+");
        private readonly Regex Subtract = new Regex(@"^-");
        private readonly Regex Multiply = new Regex(@"^(\*|×|⋅)");
        private readonly Regex Divide = new Regex(@"^(\/|÷)");
        private readonly Regex Power = new Regex(@"^(pow|\^)", RegexOptions.IgnoreCase);
        private readonly Regex Root = new Regex(@"^root", RegexOptions.IgnoreCase);
        private readonly Regex Modulo = new Regex(@"^(mod|%)", RegexOptions.IgnoreCase);
        private readonly Regex Factorial = new Regex(@"^!");
        private readonly Regex LeftBracket = new Regex(@"^\(");
        private readonly Regex RightBracket = new Regex(@"^\)");
        private readonly Regex Number = new Regex(@"^([1-9]\d*|0)((\.|,)\d+)?");
        private readonly Regex Pi = new Regex(@"^(pi|π)", RegexOptions.IgnoreCase);
        private readonly Regex Euler = new Regex(@"^(e|euler)", RegexOptions.IgnoreCase);

        private Token GetToken(string expr)
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
                return new Token(TokenType.Number, match.Value.Trim().Replace(',', '.'));

            if ((match = Pi.Match(expr)).Success)
                return new Token(TokenType.Pi, match.Value.Trim());

            if ((match = Euler.Match(expr)).Success)
                return new Token(TokenType.Euler, match.Value.Trim());

            throw new ParseException(
                $"Unknown token \"{expr}\"");
        }

        private void OptimizeNumber(List<Token> tokens)
        {
            if (tokens.Count < 2) return;

            var num = tokens[^1];
            if (num.Type != TokenType.Number &&
                num.Type != TokenType.Pi &&
                num.Type != TokenType.Euler)
                return;

            var curr = tokens[^2];
            if (curr.Type != TokenType.Add &&
                curr.Type != TokenType.Subtract)
                return;

            if(tokens.Count > 2)
            {
                var prev = tokens[^3];
                if (prev.Type == TokenType.Factorial ||
                    prev.Type == TokenType.RightBracket ||
                    prev.Type == TokenType.Number ||
                    prev.Type == TokenType.Pi ||
                    prev.Type == TokenType.Euler)
                    return;
            }

            curr.Type = num.Type;
            if (num.Type == TokenType.Number)
                curr.Value += num.Value;
            tokens.Remove(num);
        }

        public Token[] GetTokens(string expr)
        {
            expr = expr.TrimEnd();

            var tokens = new List<Token>();
            int pos = expr.Length;
            try
            {
                while (!string.IsNullOrEmpty(expr))
                {
                    pos += expr.Length;
                    expr = expr.TrimStart();
                    pos -= expr.Length;

                    var token = GetToken(expr);

                    expr = expr.Substring(token.Value.Length);
                    token.Position = pos;
                    pos += token.Value.Length;

                    tokens.Add(token);
                    OptimizeNumber(tokens);
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
