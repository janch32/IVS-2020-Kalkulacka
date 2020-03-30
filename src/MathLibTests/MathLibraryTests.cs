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
            Assert.AreEqual(3.14, (double)Library.PI, 0.01);
        }

        [TestMethod]
        public void E_Test()
        {
            Assert.AreEqual(2.7182, (double)Library.E, 0.0001);
        }

        [TestMethod]
        public void Add_Test()
        {
            decimal result = Library.Add(2.3M, 3.6M);

            Assert.AreEqual(5.9M, result);
        }

        [TestMethod]
        public void Sub_Test()
        {
            decimal result = Library.Sub(3.0M, 1.5M);

            Assert.AreEqual(1.5M, result);
        }

        [TestMethod]
        public void Sub_NegativeResult_Test()
        {
            decimal result = Library.Sub(1.5M, 1.6M);

            Assert.AreEqual(-0.1M, result);
        }

        [TestMethod]
        public void Mul_Test()
        {
            decimal result = Library.Mul(3.2M, 4.8M);

            Assert.AreEqual(15.36M, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Div_Zero_Test()
        {
            Library.Div(1.5M, 0.0M);
        }

        [TestMethod]
        public void Div_Test()
        {
            decimal result = Library.Div(1.5M, 3.0M);

            Assert.AreEqual(0.5M, result);
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
                new Tuple<int, decimal>(0, 1),
                new Tuple<int, decimal>(1, 1),
                new Tuple<int, decimal>(2, 2),
                new Tuple<int, decimal>(3, 6),
                new Tuple<int, decimal>(4, 24),
                new Tuple<int, decimal>(5, 120),
                new Tuple<int, decimal>(7, 5040),
                new Tuple<int, decimal>(15, 1307674368000)
            };

            foreach (var testCase in testCases)
            {
                decimal result = Library.Factorial(testCase.Item1);
                Assert.AreEqual(testCase.Item2, result);
            }
        }

        [TestMethod]
        public void Power_ZeroToZero_Test()
        {
            decimal result = Library.Power(0, 0);

            Assert.AreEqual(1.0M, result);
        }

        [TestMethod]
        public void Power_NToN_Test()
        {
            var testCases = new[]
            {
                new Tuple<decimal, int, decimal>(1.0M, 2, 1.0M),
                new Tuple<decimal, int, decimal>(2.0M, 2, 4.0M),
                new Tuple<decimal, int, decimal>(3.0M, 2, 9.0M),
                new Tuple<decimal, int, decimal>(4.0M, 2, 16.0M),
                new Tuple<decimal, int, decimal>(2.0M, 5, 32.0M),
                new Tuple<decimal, int, decimal>(1.4M, 2, 1.96M)
            };

            foreach (var testCase in testCases)
            {
                decimal result = Library.Power(testCase.Item1, testCase.Item2);
                Assert.AreEqual(testCase.Item3, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Root_InvalidValue_Test()
        {
            Library.Root(-15.0M, 2);
        }

        [TestMethod]
        public void Root_Test()
        {
            var testCases = new[]
            {
                new Tuple<decimal, int, decimal>(25.0M, 2, 5.0M),
                new Tuple<decimal, int, decimal>(16.0M, 2, 4.0M),
                new Tuple<decimal, int, decimal>(9.0M, 2, 3.0M),
                new Tuple<decimal, int, decimal>(4.0M, 2, 2.0M),
                new Tuple<decimal, int, decimal>(2.0M, 2, 1.41421M)
            };

            foreach (var testCase in testCases)
            {
                decimal result = Library.Root(testCase.Item1, testCase.Item2);
                Assert.AreEqual((double)testCase.Item3, (double)result, 0.00001);
            }
        }

        [TestMethod]
        public void Modulo_Test()
        {
            var testCases = new[]
            {
                new Tuple<decimal, int, decimal>(3.5M, 2, 1.5M),
                new Tuple<decimal, int, decimal>(4.8M, 3, 1.8M),
                new Tuple<decimal, int, decimal>(3.6M, 42, 3.6M),
                new Tuple<decimal, int, decimal>(18625536.15M, 156166, 41782.15M)
            };

            foreach (var testCase in testCases)
            {
                decimal result = Library.Modulo(testCase.Item1, testCase.Item2);
                Assert.AreEqual(testCase.Item3, result);
            }
        }

        [TestMethod]
        public void EvaluateExpression_Tests()
        {
            var testCases = new[]
            {
                new Tuple<string, decimal>("3,2", 3.2M),
                new Tuple<string, decimal>("1+1", 2.0M),
                new Tuple<string, decimal>("1 + 1", 2.0M),
                new Tuple<string, decimal>("1 - 1", 0.0M),
                new Tuple<string, decimal>("42 - 36", 6.0M),
                new Tuple<string, decimal>("48.6 * 32", 1555.2M),
                new Tuple<string, decimal>("2/5*4", 1.6M),
                new Tuple<string, decimal>("4^2", 16.0M),
                new Tuple<string, decimal>("√16", 4.0M),
                new Tuple<string, decimal>("2!√36√64", 2.0M),
                new Tuple<string, decimal>("16 % 2", 0.0M),
                new Tuple<string, decimal>("17 % 3", 2.0M),
                new Tuple<string, decimal>("4/2", 2.0M),
                new Tuple<string, decimal>("4!", 24.0M),
                new Tuple<string, decimal>("4! + 42*3", 150.0M),
                new Tuple<string, decimal>("(1+1)*4+42", 50.0M),
                new Tuple<string, decimal>("(((((1)+1)+1)+1)+1)*3", 15.0M),
                new Tuple<string, decimal>("(1+1) * (3/2) + 4", 7.0M),
                new Tuple<string, decimal>("400 * 500 + (42 / 3) * 3! * (3√15)", 200207.1618M),
                new Tuple<string, decimal>("(25 % 3) * 42", 42.0M),
                new Tuple<string, decimal>("10", 10.0M),
                new Tuple<string, decimal>("300.5 * 400.3", 120290.15M),
                new Tuple<string, decimal>("10.5 * 0", 0.0M),
                new Tuple<string, decimal>("((((5 + ((6 / 4.0) ^ 3)) / 1) / 10) * (8 + ((3 ^ 6) / 4))) * 2", 318.66875M),
                new Tuple<string, decimal>("3*(4^5)-2/5*(3-7)", 3073.6M),
                new Tuple<string, decimal>("              12^2^3  /  6√12^6 - 12^(2,5*2)   ", 0.0M),
                new Tuple<string, decimal>("0", 0.0M),
                new Tuple<string, decimal>("5!*5!", 14400.0M),
                new Tuple<string, decimal>("((((   1!   )  *  2!)   *   3!)    *    4!)", 288.0M),
                new Tuple<string, decimal>("1/1/1/1/1/1/1/1", 1.0M),
                new Tuple<string, decimal>("9/8/7/6", 0.02678571429M),
                new Tuple<string, decimal>("9 - 7  -  6   - 5  -   4   -3-2-1", -19.0M),
                new Tuple<string, decimal>("4^8", 65536.0M),
                new Tuple<string, decimal>("42    root    5", 1.039063628M),
                new Tuple<string, decimal>("5 % 2", 1.0M),
                new Tuple<string, decimal>("(5+1)!", 720.0M)
            };

            foreach (var testCase in testCases)
            {
                var parser = new Expression.Parser(testCase.Item1);
                Assert.AreEqual((double)testCase.Item2, (double)parser.Evaluate(), 0.0001);
            }
        }

        [TestMethod]
        public void EvaluateExpression_PI_Test()
        {
            var parser = new Expression.Parser("PI");
            Assert.AreEqual(Library.PI, parser.Evaluate());
        }

        [TestMethod]
        public void EvaluateExpression_E_Test()
        {
            var parser = new Expression.Parser("E");
            Assert.AreEqual(Library.E, parser.Evaluate());
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void UnknownOperator_Test()
        {
            new Expression.Parser("42|53").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void InvalidCountOfParenthes_Test()
        {
            new Expression.Parser("(35+42)+5)+2)").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroConstant_Test()
        {
            new Expression.Parser("6/0").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroDuringExpressionProcessing_Test()
        {
            new Expression.Parser("6/(3-3)").Evaluate();
        }


        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void UndefinedRootConstant_Test()
        {
            new Expression.Parser("root -15.0").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void UndefinedRootDuringExpressiongProcessing_Test()
        {
            new Expression.Parser("3 root (-5 * 3)").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void NegativeFactorialConstant_Test()
        {
            new Expression.Parser("-5!").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void NegativeFactorialDuringExpressionProcessing_Test()
        {
            new Expression.Parser("(6-8)!").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void OnlyVariablesInExpression_Test()
        {
            new Expression.Parser("abcdefgh").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void VariablesAndExpressions_Test()
        {
            new Expression.Parser("1 + a").Evaluate();
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void InvalidCombinationOfOperands_Test()
        {
            new Expression.Parser("1 + 2 +-*/ 4").Evaluate();
        }

        [TestMethod]
        public void EmptyExpression_Test()
        {
            var parser = new Expression.Parser("");
            Assert.AreEqual(0, parser.Evaluate());
        }
    }
}