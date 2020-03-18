namespace MathLib
{
    public static class MathLibraryFactory
    {
        public static IMathLibrary Build() => new MathLibrary();
    }
}
