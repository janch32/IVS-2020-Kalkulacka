namespace MathLib.Expression
{
    /// <summary>
    /// Individual token parsed from expression string (number, operator, function, ...).
    /// </summary>
    internal class Token
    {
        public TokenType Type;
        
        public string Value;
        
        /// <summary>
        /// Position in original expression string (from left, beginning with zero)
        /// </summary>
        public int Position;

        public Token() { }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public Token(TokenType type, string value, int pos)
        {
            Type = type;
            Value = value;
            Position = pos;
        }
    }
}
