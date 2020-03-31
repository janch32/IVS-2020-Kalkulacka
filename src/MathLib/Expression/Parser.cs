using MathLib.Exceptions;
using System.Collections.Generic;
using System;

namespace MathLib.Expression
{
    /// <summary>
    /// Parser of mathematical expressions from string
    /// </summary>
    public class Parser
    {
        private readonly Scanner Scanner = new Scanner();
        private readonly SyntaxChecker SyntaxChecker = new SyntaxChecker();
        private readonly PrecedenceTable Table = new PrecedenceTable();
        private readonly List<Token> Input;
        private readonly ParserStack Stack = new ParserStack();

        /// <summary>
        /// Initialize parser for mathemetical expression
        /// </summary>
        /// <param name="expression">Mathematical expression eg. "2 / (1 + 2) * 5"</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>")]
        public Parser(string expression)
        {
            var tokens = Scanner.GetTokens(expression);
            SyntaxChecker.VerifySyntax(tokens);

            Input = new List<Token>(tokens);
            
            // Insert "stop" tokens to the beginning of parser stack and the end
            // of input tokens list. This is used to signal end of evaluating.
            Input.Add(new Token(TokenType.None, "", -1));
            Stack.Push(new Token(TokenType.None, "", 0));
        }

        /// <summary>
        /// Evaluate provided mathematical expression
        /// </summary>
        /// <exception cref="DivideByZeroException">Throws when division by zero occurs when evaluating expression</exception>
        /// <exception cref="ArithmeticException">Throws when invalid argument occurs in math function</exception>
        /// <exception cref="ParseException">Throws when the provided string is an invalid expression</exception>
        /// <returns>Numeic result of mathematical expression</returns>
        public decimal Evaluate()
        {
            // Evaluate expression using the precedence climbing method
            // This method is fully described in 8th presentation of the IFJ course (year 2020)
            while (Input.Count > 1 || !Stack.Empty)
            {
                var token = Input[0];
                var pr = Table.GetPrecedence(token.Type, Stack.LastToken().Type);
                Stack.Push(pr);

                switch (pr)
                {
                    case Precedence.Right:
                        Stack.Push(token);
                        Input.Remove(token);
                        break;
                    // Equals is special type of right precedence used only by right 
                    // bracket token. It functions the same as right precedence with
                    // the exception of not pushing the right bracket on stack.
                    case Precedence.Equals:
                        Input.Remove(token);
                        break;
                }
            }

            try
            {
                return Stack.FirstValue();
            }
            catch (ParseException)
            {
                // If no value is on the stack (i.e. the input string is empty) 
                // prevent exception throw and instead return zero
                return 0;
            }
        }
    }
}
