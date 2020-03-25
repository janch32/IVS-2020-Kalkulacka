using MathLib.Exceptions;

namespace MathLib.Expression
{
    class SyntaxChecker
    {
        private bool VerifyTokenRelation(TokenType current, TokenType prev)
        {
            switch (current)
            {
                case TokenType.Add:
                case TokenType.Subtract:
                case TokenType.Multiply:
                case TokenType.Divide:
                case TokenType.Power:
                case TokenType.Root:
                case TokenType.Modulo:
                case TokenType.Factorial:
                case TokenType.RightBracket:
                    return prev == TokenType.Number ||
                        prev == TokenType.Pi ||
                        prev == TokenType.Euler ||
                        prev == TokenType.RightBracket ||
                        prev == TokenType.Factorial;
                case TokenType.LeftBracket:
                case TokenType.Number:
                case TokenType.Pi:
                case TokenType.Euler:
                    return prev != TokenType.Number &&
                        prev != TokenType.Pi &&
                        prev != TokenType.Euler &&
                        prev != TokenType.Factorial &&
                        prev != TokenType.RightBracket;
            }

            return false;
        }

        public void VerifySyntax(Token[] tokens)
        {
            Token prev = null;
            foreach (var curr in tokens)
            {
                var allowed = VerifyTokenRelation(
                    curr.Type, prev?.Type ?? TokenType.None);

                if (allowed)
                {
                    prev = curr;
                    continue;
                }
                
                if (prev == null)
                {
                    throw new ParseException(
                        $"Syntax Error: Expression cannot start with type " +
                        $"{curr.Type}(\"{curr.Value}\")");
                }
                
                throw new ParseException(
                    $"Syntax Error: Incompatible type {prev.Type}(\"{prev.Value}\") with" +
                    $" {curr.Type}(\"{curr.Value}\") on pos {curr.Position}");
            }
        }
    }
}
