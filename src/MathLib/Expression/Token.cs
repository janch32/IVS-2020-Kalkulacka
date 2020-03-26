namespace MathLib.Expression
{
    internal class Token
    {
        public TokenType Type;
        public string Value;
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
