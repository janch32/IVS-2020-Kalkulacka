using MathLib.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLib.Tests
{
    [TestClass]
    public class MathLibraryTests
    {
        private IMathLibrary Library { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Library = MathLibraryFactory.Build();
        }

        [TestMethod]
        public void PI_Test()
        {
            Assert.AreEqual(3.14, Library.PI, 0.01);
        }

        [TestMethod]
        public void E_Test()
        {
            Assert.AreEqual(2.71, Library.E, 0.01);
        }

        [TestMethod]
        public void Add_Test()
        {
            double result = Library.Add(2.3, 3.6);

            Assert.AreEqual(5.9, result, 0.01);
        }

        [TestMethod]
        public void Sub_Test()
        {
            double result = Library.Sub(3.0, 1.5);

            Assert.AreEqual(1.5, result, 0.01);
        }

        [TestMethod]
        public void Sub_NegativeResult_Test()
        {
            double result = Library.Sub(1.5, 1.6);

            Assert.AreEqual(-0.1, result, 0.01);
        }

        [TestMethod]
        public void Mul_Test()
        {
            double result = Library.Mul(3.2, 4.8);

            Assert.AreEqual(15.36, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Div_Zero_Test()
        {
            Library.Div(1.5, 0.0);
        }

        [TestMethod]
        public void Div_Test()
        {
            double result = Library.Div(1.5, 3.0);

            Assert.AreEqual(0.5, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Factorial_Negative_Test()
        {
            Library.Factorial(-1);
        }

        [TestMethod]
        public void Factorial_Test()
        {
            var testCases = new[] {
                new Tuple<int, long>(0, 1),
                new Tuple<int, long>(1, 1),
                new Tuple<int, long>(2, 2),
                new Tuple<int, long>(3, 6),
                new Tuple<int, long>(4, 24),
                new Tuple<int, long>(5, 120),
                new Tuple<int, long>(7, 5040),
                new Tuple<int, long>(15, 1307674368000)
            };

            foreach (var testCase in testCases)
            {
                long result = Library.Factorial(testCase.Item1);
                Assert.AreEqual(testCase.Item2, result);
            }
        }

        [TestMethod]
        public void Power_ZeroToZero_Test()
        {
            double result = Library.Power(0.0, 0);

            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void Power_NToN_Test()
        {
            var testCases = new[]
            {
                new Tuple<double, int, double>(1.0, 2, 1.0),
                new Tuple<double, int, double>(2.0, 2, 4.0),
                new Tuple<double, int, double>(3.0, 2, 9.0),
                new Tuple<double, int, double>(4.0, 2, 16.0),
                new Tuple<double, int, double>(2.0, 5, 32.0),
                new Tuple<double, int, double>(1.4, 2, 1.96)
            };

            foreach (var testCase in testCases)
            {
                double result = Library.Power(testCase.Item1, testCase.Item2);
                Assert.AreEqual(testCase.Item3, result, 0.1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Root_InvalidValue_Test()
        {
            Library.Root(-15.0, 2);
        }

        [TestMethod]
        public void Root_Test()
        {
            var testCases = new[]
            {
                new Tuple<double, int, double>(25.0, 2, 5.0),
                new Tuple<double, int, double>(16.0, 2, 4.0),
                new Tuple<double, int, double>(9.0, 2, 3.0),
                new Tuple<double, int, double>(4.0, 2, 2.0),
                new Tuple<double, int, double>(2.0, 2, 1.41421)
            };

            foreach (var testCase in testCases)
            {
                double result = Library.Root(testCase.Item1, testCase.Item2);
                Assert.AreEqual(testCase.Item3, result, 0.00001);
            }
        }

        [TestMethod]
        public void Modulo_Test()
        {
            var testCases = new[]
            {
                new Tuple<double, int, double>(3.5, 2, 1.5),
                new Tuple<double, int, double>(4.8, 3, 1.8),
                new Tuple<double, int, double>(3.6, 42, 3.6),
                new Tuple<double, int, double>(18625536.15, 156166, 41782.15)
            };

            foreach (var testCase in testCases)
            {
                double result = Library.Modulo(testCase.Item1, testCase.Item2);
                Assert.AreEqual(testCase.Item3, result, 0.001);
            }
        }

        [TestMethod]
        public void EvaluateExpression_Tests()
        {
            var testCases = new[]
            {
                new Tuple<string, double>("1+1", 2.0),
                new Tuple<string, double>("1 + 1", 2.0),
                new Tuple<string, double>("1 - 1", 0.0),
                new Tuple<string, double>("42 - 36", 6.0),
                new Tuple<string, double>("48.6 * 32", 1555.2),
                new Tuple<string, double>("4^2", 16.0),
                new Tuple<string, double>("16 root 2", 4.0),
                new Tuple<string, double>("16 % 2", 0.0),
                new Tuple<string, double>("17 % 3", 2.0),
                new Tuple<string, double>("4/2", 2.0),
                new Tuple<string, double>("4!", 24.0),
                new Tuple<string, double>("4! + 42*3", 150.0),
                new Tuple<string, double>("(1+1)*4+42", 50.0),
                new Tuple<string, double>("(((((1)+1)+1)+1)+1)*3", 12.0),
                new Tuple<string, double>("(1+1) * (3/2) + 4", 7.0),
                new Tuple<string, double>("400 * 500 + (42 / 3) * 3! * (15 root 3)", 200207.1618),
                new Tuple<string, double>("(25 % 3) * 42", 42.0),
                new Tuple<string, double>("10", 10.0),
                new Tuple<string, double>("300.5 * 400.3", 120290.15),
                new Tuple<string, double>("10.5 * 0", 0.0),
                new Tuple<string, double>("((((5 + ((6 / 4.0) ^ 3)) / 1) / 10) * (8 + ((3 ^ 6) / 4))) * 2", 318.66875),
                new Tuple<string, double>("3*(4^5)-2/5*(3-7)", 3073.6),
                new Tuple<string, double>("              3348.36562                        *                   12 ^ 6", 9998166167.0),
                new Tuple<string, double>("0", 0.0),
                new Tuple<string, double>("5!*5!", 14400.0),
                new Tuple<string, double>("((((   1!   )  *  2!)   *   3!)    *    4!)", 288.0),
                new Tuple<string, double>("1/1/1/1/1/1/1/1", 1.0),
                new Tuple<string, double>("9/8/7/6", 0.02678571429),
                new Tuple<string, double>("9 - 7  -  6   - 5  -   4   -3-2-1", -27.0),
                new Tuple<string, double>("4^8", 65536.0),
                new Tuple<string, double>("5    root    42", 1.039063628),
                new Tuple<string, double>("5 % 2", 1.0),
                new Tuple<string, double>("(5+1)!", 720.0)
            };

            foreach (var testCase in testCases)
            {
                double result = Library.EvaluateExpression(testCase.Item1);
                Assert.AreEqual(testCase.Item2, result, 0.1);
            }
        }

        [TestMethod]
        public void EvaluateExpression_PI_Test()
        {
            double result = Library.EvaluateExpression("PI");
            Assert.AreEqual(Library.PI, result);
        }

        [TestMethod]
        public void EvaluateExpression_E_Test()
        {
            double result = Library.EvaluateExpression("E");
            Assert.AreEqual(Library.E, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionParseException))]
        public void UnknownOperator_Test()
        {
            Library.EvaluateExpression("42|53");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionParseException))]
        public void InvalidCountOfParenthes_Test()
        {
            Library.EvaluateExpression("(35+42)+5)+2)");
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void DivisionByZeroConstant_Test()
        {
            Library.EvaluateExpression("6/0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void DivisionByZeroDuringExpressionProcessing_Test()
        {
            Library.EvaluateExpression("6/(3-3)");
        }


        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void UndefinedRootConstant_Test()
        {
            Library.EvaluateExpression("-15.0 root 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void UndefinedRootDuringExpressiongProcessing_Test()
        {
            Library.EvaluateExpression("(-5 * 3) root 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void NegativeFactorialConstant_Test()
        {
            Library.EvaluateExpression("-5!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void NegativeFactorialDuringExpressionProcessing_Test()
        {
            Library.EvaluateExpression("(6-8)!");
        }
    }
}