using CSharpKatas.TicTacToe;

namespace CSharpKataTests.TicTacToe
{
    public class MockConsole : IUserInterface
    {
        public char EmptyCell => '0';

        public string GetUserInput()
        {
            return string.Empty;
        }

        public void ShowEnd()
        {

        }

        public void ShowInvalidChoice()
        {

        }

        public void ShowTurn(Player[] players, string currentPlayerName, char[] cells)
        {

        }

        public void ShowWin(string playerName, char[] cells)
        {

        }
    }
}