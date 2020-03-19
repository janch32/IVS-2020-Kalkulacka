using System;

namespace MathLib
{
    public class MathLibrary : IMathLibrary
    {
        public double PI => throw new NotImplementedException();

        public double E => throw new NotImplementedException();

        public double Add(double a, double b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Substracts two numbers
        /// </summary>
        /// <param name="a">First number (left side)</param>
        /// <param name="b">Second number (right side)</param>
        /// <returns>Result of the substraction</returns>
        public double Sub(double a, double b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="a">First number (left side)</param>
        /// <param name="b">Second number (right side)</param>
        /// <returns>Result of the multiplication</returns>
        public double Mul(double a, double b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="a">Dividend (left side)</param>
        /// <param name="b">Divisor (right side). Must not be zero!</param>
        /// <exception cref="DivideByZeroException">Tthrows when the value of the divisor is zero</exception>
        /// <returns>Result of the division</returns>
        public double Div(double a, double b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="x">Dividend (left side)</param>
        /// <returns>Result of the division</returns>
        public long Factorial(int x)
        {
            throw new NotImplementedException();
        }

        public double Power(double a, int n)
        {
            throw new NotImplementedException();
        }

        public double Root(double a, int n)
        {
            throw new NotImplementedException();
        }

        public double Modulo(double a, int b)
        {
            throw new NotImplementedException();
        }

        public double EvaluateExpression(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
