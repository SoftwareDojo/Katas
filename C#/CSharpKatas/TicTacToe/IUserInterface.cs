namespace CSharpKatas.TicTacToe
{
    public interface IUserInterface
    {
        char EmptyCell { get; }
        string GetUserInput();
        void ShowEnd();
        void ShowInvalidChoice();
        void ShowTurn(Player[] players, string currentPlayerName, char[] cells);
        void ShowWin(string playerName, char[] cells);
    }
}