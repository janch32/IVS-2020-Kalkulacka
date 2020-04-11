namespace MathLib.Expression
{
    /// <summary>
    /// ++=======++=======================================================++
    /// ||       ||  + -  | * / % |   !   | ^root | ( val |   )   |   $   ||
    /// ++=======++=======================================================++
    /// ||  + -  ||   >   |   <   |   <   |   <   |   <   |   >   |   >   ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// || * / % ||   >   |   >   |   <   |   <   |   <   |   >   |   >   ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// ||   !   ||   >   |   >   |   >   |   >   |       |   >   |   >   ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// || ^root ||   >   |   >   |   <   |   >   |   <   |   >   |   >   ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// ||   (   ||   <   |   <   |   <   |   <   |   <   |   =   |       ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// || ) val ||   >   |   >   |   >   |   >   |       |   >   |   >   ||
    /// ||-------||-------+-------+-------+-------+-------+-------+-------||
    /// ||   $   ||   <   |   <   |   <   |   <   |   <   |       |       ||
    /// ++=======++=======================================================++
    /// *val = number, pi, euler
    /// </summary>
    internal class PrecedenceTable
    {
        private Precedence NonePrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.None:
                case TokenType.RightBracket:
                    return Precedence.None;
            }

            return Precedence.Right;
        }

        private Precedence AddSubPrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.None:
                case TokenType.Add:
                case TokenType.Subtract:
                case TokenType.RightBracket:
                    return Precedence.Left;
            }

            return Precedence.Right;
        }

        private Precedence MulDivModPrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.None:
                case TokenType.Add:
                case TokenType.Subtract:
                case TokenType.Multiply:
                case TokenType.Divide:
                case TokenType.Modulo:
                case TokenType.RightBracket:
                    return Precedence.Left;
            }

            return Precedence.Right;
        }

        private Precedence FactorialPrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.LeftBracket:
                case TokenType.Number:
                case TokenType.Pi:
                case TokenType.Euler:
                    return Precedence.None;
            }

            return Precedence.Left;
        }

        private Precedence PowRootPrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.Factorial:
                case TokenType.LeftBracket:
                case TokenType.Number:
                case TokenType.Pi:
                case TokenType.Euler:
                    return Precedence.Right;
            }

            return Precedence.Left;
        }

        private Precedence LeftBracketPrecedence(TokenType curr)
        {
            if (curr == TokenType.RightBracket) return Precedence.Equals;
            if (curr == TokenType.None) return Precedence.None;
            return Precedence.Right;
        }

        // TODO: From warning: Update this method so that its implementation is not identical to 'FactorialPrecedence'.
        private Precedence ValRBracketPrecedence(TokenType curr)
        {
            switch (curr)
            {
                case TokenType.LeftBracket:
                case TokenType.Number:
                case TokenType.Pi:
                case TokenType.Euler:
                    return Precedence.None;
            }

            return Precedence.Left;
        }

        /// <summary>
        /// Returns precendence of two tokens from precedence lookup table
        /// </summary>
        /// <param name="curr">Current (new) token</param>
        /// <param name="prev">Previous token</param>
        /// <returns>Precedence of current token in relation to previous token</returns>
        public Precedence GetPrecedence(TokenType curr, TokenType prev)
        {
            switch (prev)
            {
                case TokenType.None:
                    return NonePrecedence(curr);
                case TokenType.Add:
                case TokenType.Subtract:
                    return AddSubPrecedence(curr);
                case TokenType.Multiply:
                case TokenType.Divide:
                case TokenType.Modulo:
                    return MulDivModPrecedence(curr);
                case TokenType.Power:
                case TokenType.Root:
                    return PowRootPrecedence(curr);
                case TokenType.Factorial:
                    return FactorialPrecedence(curr);
                case TokenType.LeftBracket:
                    return LeftBracketPrecedence(curr);
                case TokenType.RightBracket:
                case TokenType.Number:
                case TokenType.Pi:
                case TokenType.Euler:
                    return ValRBracketPrecedence(curr);
            }

            return Precedence.None;
        }
    }
}
