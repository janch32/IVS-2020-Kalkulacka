using System;
using MathLib.Expression;

namespace MathLib
{
    public class MathLibrary : IMathLibrary
    {
        private readonly Scanner ExprScanner = new Scanner();
        private readonly SyntaxChecker ExprSyntaxChecker = new SyntaxChecker();

        public decimal PI => 3.141592653589793M;

        public decimal E => 2.718281828459045M;

        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Sub(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Mul(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal Div(decimal a, decimal b)
        {
            if (b == 0) throw new DivideByZeroException();

            return a / b;
        }

        public decimal Factorial(decimal x)
        {
            if (x < 0) throw new ArithmeticException(
                 "Factorial can only be calculated from positive number");

            if (x % 1 != 0) throw new ArithmeticException(
                "Factorial can only be calculated from decimal number");

            var res = x > 1 ? x : 1;
            while (x-- > 2) res *= x;
            return res;
        }

        public decimal Power(decimal a, decimal n)
        {
            if (n % 1 != 0) throw new ArithmeticException(
                "Power exponent must be decimal number");

            if (n < 0)
            {
                n = -n;
                a = 1 / a;
            }

            var res = 1M;
            while (n-- > 0) res *= a;
            return res;
        }

        public decimal Root(decimal a, decimal n)
        {
            if (a < 0) throw new ArithmeticException(
                "Root can only by calculated from positive number");

            if (n % 1 != 0) throw new ArithmeticException(
                "Root must be decimal number");

            if (n < 0)
            {
                n = -n;
                a = 1 / a;
            }

            // TODO předělat na decimal
            return (decimal)Math.Pow((double)a, (double)(1 / n));
        }

        public decimal Modulo(decimal a, decimal b)
        {
            if (b == 0) throw new DivideByZeroException();

            if (b < 0) throw new ArithmeticException(
                "Modulo divisor must be decimal number");

            return a % b;
        }
    }
}
