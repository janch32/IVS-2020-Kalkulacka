using MathLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib.Expression
{
    class Parser
    {
        private List<Token> InputTokens;
        private PrecedenceTable PrecedenceTable = new PrecedenceTable();

        // Jo, dal jsem tam object, zažaluj mě
        //
        // Ale kdyby byla jiná cesta jak do listu narvat Token, NonTerm a Enum,
        // tak bych to rád zkrášlil. Zatím jsem ale na nic jiného nepřišel.
        private List<object> EvaluateStack = new List<object>();

        public Parser(Token[] tokens)
        {
            InputTokens = new List<Token>(tokens);
            InputTokens.Add(new Token(TokenType.None, "", -1));
            EvaluateStack.Add(new Token(TokenType.None, "", 0));
        }

        private void Parse(Token input)
        {
            
        }
    }
}
