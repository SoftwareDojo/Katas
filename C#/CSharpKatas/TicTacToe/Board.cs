using System.Collections.Generic;

//http://tuts4you.de/87-programmieren/csharp/90-c-spiel-tutorial-tictactoe

namespace CSharpKatas.TicTacToe
{
    public class Board
    {
        private readonly int m_Size;
        private readonly IList<Token> m_Token; 

        public Board(int size)
        {
            m_Size = size;
            m_Token = new List<Token>();
        }

        public bool SetToken(int x, int y, string value)
        {
            var token = new Token(x, y, value);
            if (!IsPositionValid(token.Position)) return false;
            if (IsPositionUsed(token.Position)) return false;

            m_Token.Add(token);

            return true;
        }

        private bool IsPositionValid(Position position)
        {
            if (position.X < 0 || position.X >= m_Size) return false;
            if (position.Y < 0 || position.Y >= m_Size) return false;

            return true;
        }

        private bool IsPositionUsed(Position position)
        {
            foreach (var token in m_Token)
            {
                if (token.Position.Equals(position)) return true;
            }

            return false;
        }
    }
}