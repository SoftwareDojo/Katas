using CSharpKatas.TicTacToe;

namespace CSharpKatas.TicTacToe
{
    public class TicTacToeGame
    {
        private const int s_BoardSize = 3;
        private readonly Board m_Board;

        public TicTacToeGame()
        {
            m_Board = new Board(s_BoardSize);
        }
    }
}
