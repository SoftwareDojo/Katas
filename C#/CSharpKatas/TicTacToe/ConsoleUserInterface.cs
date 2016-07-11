using System;
using System.Threading.Tasks;

namespace CSharpKatas.TicTacToe
{
    public class ConsoleUserInterface : IUserInterface
    {
        public char EmptyCell => '0';

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void ShowEnd()
        {
            Console.WriteLine("Game over!");
            Console.ReadLine();
        }

        public void ShowInvalidChoice()
        {
            Console.WriteLine("The cell is already marked or invalid.\n");
            Console.WriteLine("Please wait 2 seconds, board is loading again...");
            Task.Delay(2000).Wait();
        }

        public void ShowTurn(Player[] players, string currentPlayerName, char[] cells)
        {
            Console.Clear();
            Console.WriteLine($"{players[0].Name}:{players[0].Token} and {players[1].Name}:{players[1].Token}\n");
            Console.WriteLine($"{currentPlayerName} chance\n");
            ShowBoard(cells);
        }

        public void ShowWin(string playerName, char[] cells)
        {
            Console.Clear();
            ShowBoard(cells);
            Console.WriteLine($"{playerName} has won!");
        }

        private void ShowBoard(char[] cells)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(0, cells)}  |  {GetCellValue(1, cells)}  |  {GetCellValue(2, cells)}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(3, cells)}  |  {GetCellValue(4, cells)}  |  {GetCellValue(5, cells)}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {GetCellValue(6, cells)}  |  {GetCellValue(7, cells)}  |  {GetCellValue(8, cells)}");
            Console.WriteLine("     |     |      ");
        }

        private string GetCellValue(int index, char[] cells)
        {
            if (cells[index] == EmptyCell) return (index + 1).ToString();
            return cells[index].ToString();
        }
    }
}
