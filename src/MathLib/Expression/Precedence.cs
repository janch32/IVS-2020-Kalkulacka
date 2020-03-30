namespace MathLib.Expression
{
    /// <summary>
    /// Type of precedence. Used to compare precedence between operators
    /// </summary>
    internal enum Precedence
    {
        Left,
        Right,
        Equals,
        None
    }
}
