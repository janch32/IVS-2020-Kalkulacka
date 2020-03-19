using System;
using MathLib.Exceptions;

namespace MathLib
{
    public interface IMathLibrary
    {
        /// <summary>
        /// Pi - mathematical constant
        /// </summary>
        double PI { get; }

        /// <summary>
        /// Euler's number - mathematical constant
        /// </summary>
        double E { get; }

        /// <summary>
        /// Add two numbers
        /// </summary>
        /// <param name="a">First number (left side)</param>
        /// <param name="b">Second number (right side)</param>
        /// <returns>Addition result</returns>
        double Add(double a, double b);

        /// <summary>
        /// Substract two numbers
        /// </summary>
        /// <param name="a">First number (left side)</param>
        /// <param name="b">Second number (right side)</param>
        /// <returns>Substraction result</returns>
        double Sub(double a, double b);

        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="a">First number (left side)</param>
        /// <param name="b">Second number (right side)</param>
        /// <returns>Multiplication result</returns>
        double Mul(double a, double b);

        /// <summary>
        /// Divide two numbers
        /// </summary>
        /// <param name="a">Dividend (left side)</param>
        /// <param name="b">Divisor (right side). Must not be zero!</param>
        /// <exception cref="DivideByZeroException">Throws when the value of the divisor is zero</exception>
        /// <returns>Division result</returns>
        double Div(double a, double b);

        /// <summary>
        /// Calculate factorial
        /// </summary>
        /// <param name="n">Number greater then or equal to zero</param>
        /// <exception cref="ArithmeticException">Throws when the provided number is negative</exception>
        /// <returns>Factorial result</returns>
        long Factorial(int n);

        /// <summary>
        /// Calculate exponentiation of base <c>a</c> to the power of <c>n</c>
        /// </summary>
        /// <param name="a">Base</param>
        /// <param name="n">Exponent</param>
        /// <returns>Exponentiation result</returns>
        double Power(double a, int n);

        /// <summary>
        /// Calculate <c>n</c>th root of a number <c>a</c>, also known as root extraction
        /// </summary>
        /// <param name="a">Base</param>
        /// <param name="n">Root</param>
        /// <exception cref="ArithmeticException">Throws when the base is negative</exception>
        /// <returns>Root exraction result</returns>
        double Root(double a, int n);

        /// <summary>
        /// Calculate remainder of two integer division
        /// </summary>
        /// <param name="a">Dividend (left side)</param>
        /// <param name="b">Divisor (right side). Must not be zero!</param>
        /// <exception cref="DivideByZeroException">Throws when the value of the divisor is zero</exception>
        /// <returns>Integer division remainder</returns>
        double Modulo(double a, int b);

        /// <summary>
        /// Parse and evaluate provided mathematical expression
        /// </summary>
        /// <param name="expression">Mathematical expression eg. "2 / (1 + 2) * 5"</param>
        /// <exception cref="DivideByZeroException">Throws when division by zero happens when evaluating expression</exception>
        /// <exception cref="ArithmeticException">Throws when invalid argument occurs in math function</exception>
        /// <exception cref="ExpressionParseException">Throws when the provided string is an invalid expression</exception>
        /// <returns>Mathematical expression result</returns>
        double EvaluateExpression(string expression);
    }
}
