using MathLib.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Useless warnings
#pragma warning disable S1121, RCS1192

namespace MathLib.Expression
{
    /// <summary>
    /// Scanner that splits expression string to individual <see cref="Token"/>s
    /// </summary>
    internal class Scanner
    {
        #region Regex rules for individual tokens
        private readonly Regex Add = new Regex(@"^\+");
        private readonly Regex Subtract = new Regex(@"^(-|−)");
        private readonly Regex Multiply = new Regex(@"^(\*|×|⋅)");
        private readonly Regex Divide = new Regex(@"^(\/|÷)");
        private readonly Regex Power = new Regex(@"^(pow|\^)", RegexOptions.IgnoreCase);
        private readonly Regex Root = new Regex(@"^(root|√)", RegexOptions.IgnoreCase);
        private readonly Regex Modulo = new Regex(@"^(mod|%)", RegexOptions.IgnoreCase);
        private readonly Regex Factorial = new Regex(@"^!");
        private readonly Regex LeftBracket = new Regex(@"^\(");
        private readonly Regex RightBracket = new Regex(@"^\)");
        private readonly Regex Number = new Regex(@"^\d+((\.|,)\d+)?");
        private readonly Regex Pi = new Regex(@"^(pi|π|𝜋)", RegexOptions.IgnoreCase);
        private readonly Regex Euler = new Regex(@"^(e|euler|ℇ)", RegexOptions.IgnoreCase);
        #endregion

        /// <summary>
        /// Get leftmost token from provided mathematical expression
        /// </summary>
        /// <param name="expr">Mathematical expression</param>
        /// <exception cref="ParseException">Throws when expression contains unexpected sequence of characters</exception>
        /// <returns>Leftmost token of expression</returns>
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

        /// <summary>
        /// Merges neighboring add/sub token and number token if the re is no other neighboring number operator.
        /// This is done as workaroud about negative numbers
        /// </summary>
        /// <param name="tokens">List of all scanned tokens</param>
        private void Optimize(List<Token> tokens)
        {
            if (tokens.Count < 2) return;

            var num = tokens[^1];
            if (num.Type != TokenType.Number &&
                num.Type != TokenType.Pi &&
                num.Type != TokenType.Euler &&
                num.Type != TokenType.Root)
            {
                return;
            }

            var curr = tokens[^2];
            if (curr.Type != TokenType.Add &&
                curr.Type != TokenType.Subtract)
            {
                return;
            }

            if (tokens.Count > 2)
            {
                var prev = tokens[^3];
                if (prev.Type == TokenType.Factorial ||
                    prev.Type == TokenType.RightBracket ||
                    prev.Type == TokenType.Number ||
                    prev.Type == TokenType.Pi ||
                    prev.Type == TokenType.Euler)
                {
                    return;
                }
            }

            curr.Type = num.Type;
            if (num.Type == TokenType.Number)
                curr.Value += num.Value;
            tokens.Remove(num);
        }

        /// <summary>
        /// Split provided expression string to array of <see cref="Token"/>s
        /// </summary>
        /// <param name="expr">Mathematical expression</param>
        /// <exception cref="ParseException">Throws when scanner finds unexpected sequence of characters in source string</exception>
        /// <returns>Array of tokens from input string</returns>
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
                    Optimize(tokens);
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
