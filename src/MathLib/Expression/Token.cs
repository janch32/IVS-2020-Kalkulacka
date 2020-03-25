namespace MathLib.Expression
{
    class Token
    {
        public TokenType Type;
        public string Value;
        public int Position;

        public Token() {}

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
