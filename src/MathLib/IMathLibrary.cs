namespace MathLib
{
    public interface IMathLibrary
    {
        double PI { get; }
        double E { get; }

        double Add(double a, double b);
        double Sub(double a, double b);
        double Mul(double a, double b);
        double Div(double a, double b);

        long Factorial(int x);
        double Power(double a, int n);
        double Root(double a, int n);

        double Modulo(double a, int b);

        double CalculateException(string expression);
    }
}
