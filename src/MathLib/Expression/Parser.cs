using MathLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib.Expression
{
    class Parser
    {
        private PrecedenceTable Table = new PrecedenceTable();
        private List<Token> Input;
        private ParserStack Stack = new ParserStack();
        
        public Parser(Token[] tokens)
        {
            Input = new List<Token>(tokens);
            Input.Add(new Token(TokenType.None, "", -1));
            Stack.Push(new Token(TokenType.None, "", 0));
        }

        public double Evaluate()
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
