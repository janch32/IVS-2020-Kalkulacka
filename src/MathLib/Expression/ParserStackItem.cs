namespace MathLib.Expression
{
    /// <summary>
    /// This class defines all permitted types that can be pushed to the parser stack.
    /// </summary>
    /// <see cref="ParserStack"/>
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
