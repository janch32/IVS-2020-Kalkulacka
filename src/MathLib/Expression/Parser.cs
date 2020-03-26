using MathLib.Exceptions;
using System.Collections.Generic;

namespace MathLib.Expression
{
    public class Parser
    {
        private Scanner Scanner = new Scanner();
        private SyntaxChecker SyntaxChecker = new SyntaxChecker();
        private PrecedenceTable Table = new PrecedenceTable();
        private List<Token> Input;
        private ParserStack Stack = new ParserStack();

        internal Parser(Token[] tokens)
        {
            Initialize(tokens);
        }

        /// <summary>
        /// Initialize parser for mathemetical expression
        /// </summary>
        /// <param name="expression">Mathematical expression eg. "2 / (1 + 2) * 5"</param>
        public Parser(string expression)
        {
            var tokens = Scanner.GetTokens(expression);
            SyntaxChecker.VerifySyntax(tokens);

            Initialize(tokens);
        }

        private void Initialize(Token[] tokens)
        {
            Input = new List<Token>(tokens);
            Input.Add(new Token(TokenType.None, "", -1));
            Stack.Push(new Token(TokenType.None, "", 0));
        }

        /// <summary>
        /// Evaluate provided mathematical expression
        /// </summary>
        /// <exception cref="DivideByZeroException">Throws when division by zero happens when evaluating expression</exception>
        /// <exception cref="ArithmeticException">Throws when invalid argument occurs in math function</exception>
        /// <exception cref="ParseException">Throws when the provided string is an invalid expression</exception>
        /// <returns>Mathematical expression result</returns>
        public decimal Evaluate()
        {
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
                return 0;
            }
        }
    }
}
