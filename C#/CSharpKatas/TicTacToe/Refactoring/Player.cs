using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpKatas.TicTacToe.Refactoring
{
    public class Player
    { 
        public string Name { get; }
        public char Token { get; }

        public Player(string name, char token)
        {
            Name = name;
            Token = token;
        }
    }
}
