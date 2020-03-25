using System;
using MathLib.Expression;

namespace MathLib
{
    public class MathLibrary : IMathLibrary
    {
        public double PI => 3.141592653589793;

        public double E => 2.718281828459045;

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();

            return a / b;
        }

        public double Factorial(double x)
        {
            if(x < 0) throw new ArithmeticException(
                "Factorial can only be calculated from positive number");

            if (x % 1 == 0) throw new ArithmeticException(
                "Factorial can only be calculated from decimal number");

            var res = x > 1 ? x : 1.0;
            while (x-- > 2) res *= x;
            return res;
        }

        public double Power(double a, double n)
        {
            if (n % 1 == 0) throw new ArithmeticException(
                "Power exponent must be decimal number");

            if (n < 0)
            {
                n = -n;
                a = 1 / a;
            }

            var res = 1.0;
            while (n-- > 0) res *= a;
            return res;
        }

        public double Root(double a, double n)
        {
            if (a < 0) throw new ArithmeticException(
                "Root can only by calculated from positive number");

            if (n % 1 == 0) throw new ArithmeticException(
                "Root must be decimal number");

            return Math.Pow(a, 1.0 / n); 
        }

        public double Modulo(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();

            if (b < 0) throw new ArithmeticException(
                "Modulo divisor must be decimal number");
            
            return a % b;
        }

        private Scanner ExprScanner = new Scanner();
        private SyntaxChecker ExprSyntaxChecker = new SyntaxChecker();
        
        public double EvaluateExpression(string expression)
        {
            var tokens = ExprScanner.GetTokens(expression);
            ExprSyntaxChecker.VerifySyntax(tokens);

            throw new NotImplementedException();
        }
    }
}
