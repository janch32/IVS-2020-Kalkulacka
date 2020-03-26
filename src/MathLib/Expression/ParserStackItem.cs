namespace MathLib.Expression
{
    internal class ParserStackItem
    {
        public readonly decimal? Value = null;
        public readonly Token Token = null;
        public readonly Precedence? Precedence = null;

        public ParserStackItem(Token token) => Token = token;
        
        public ParserStackItem(decimal value) => Value = value;
        
        public ParserStackItem(Precedence precedence) => Precedence = precedence;

    }
}
