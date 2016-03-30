using System.Linq;
using System.Threading.Tasks;

namespace CSharpKatas.TicTacToe
{
    public class TicTacToeGame
    {
        private readonly IConsole m_Console;
        private readonly Player[] m_Players;
        private Player m_CurrentPlayer;
        internal const char EmptyCell = '0';
        private readonly char[] m_Cells;

        public static TicTacToeGame Default()
        {
            return new TicTacToeGame(
                new ConsoleAdapter(), 
                new[]
                {
                    EmptyCell, EmptyCell, EmptyCell,
                    EmptyCell, EmptyCell, EmptyCell,
                    EmptyCell, EmptyCell, EmptyCell
                }, 
                new[]
                {
                    new Player("Player 1", 'X'),
                    new Player("Player 2", 'O')
                });
        }

        public TicTacToeGame(IConsole console, char[] cells, Player[] player)
        {
            m_Console = console;
            m_Cells = cells;
            m_Players = player;
        }

        public void Start()
        {
            m_CurrentPlayer = m_Players[0];

            while (true)
            {
                PrintTurn();

                if (!Turn())
                {
                    PrintInvalidChoice();
                    continue;
                }

                if (PlayerWins(m_CurrentPlayer.Token))
                {
                    PrintWin();
                    break;
                }

                if (IsDraw()) break;

                NextPlayer();
            }

            m_Console.WriteLine("Game over!");
            m_Console.ReadLine();
        }

        private bool Turn()
        {
            int index;
            bool isIntValue = int.TryParse(m_Console.ReadLine(), out index);
            if (isIntValue) index = index - 1;

            if (!isIntValue || index < 0 || index > 8 || m_Cells[index] != EmptyCell)
            {
                return false;
            }

            m_Cells[index] = m_CurrentPlayer.Token;
            return true;
        }

        private void NextPlayer()
        {
            if (m_CurrentPlayer == m_Players[0]) m_CurrentPlayer = m_Players[1];
            else m_CurrentPlayer = m_Players[0];
        }

        private string GetCellValue(int index)
        {
            if (m_Cells[index] == EmptyCell) return (index + 1).ToString();
            return m_Cells[index].ToString();
        }

        internal bool PlayerWins(char value)
        {
            for (int i = 0; i < 7; i = i + 3)
            {
                if (CheckCellValues(value, i, i + 1, i + 2)) return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (CheckCellValues(value, i, i + 3, i + 6)) return true;
            }

            if (CheckCellValues(value, 0, 4, 8)) return true;
            if (CheckCellValues(value, 2, 4, 6)) return true;

            return false;
        }

        internal bool IsDraw()
        {
            return !m_Cells.Any(a => a == EmptyCell);
        }

        private bool CheckCellValues(char value, int index1, int index2, int index3)
        {
            return m_Cells[index1] == value && m_Cells[index2] == value && m_Cells[index3] == value;
        }

        private void PrintInvalidChoice()
        {
            m_Console.WriteLine($"The cell is already marked or invalid.\n");
            m_Console.WriteLine("Please wait 2 seconds, board is loading again...");
            Task.Delay(2000).Wait();
        }

        private void PrintTurn()
        {
            m_Console.Clear();
            m_Console.WriteLine($"{m_Players[0].Name}:{m_Players[0].Token} and {m_Players[1].Name}:{m_Players[1].Token}\n");
            m_Console.WriteLine($"{m_CurrentPlayer.Name} chance\n");
            PrintBoard();
        }

        private void PrintWin()
        {
            m_Console.Clear();
            PrintBoard();
            m_Console.WriteLine($"{m_CurrentPlayer.Name} has won");
        }

        private void PrintBoard()
        {
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {GetCellValue(0)}  |  {GetCellValue(1)}  |  {GetCellValue(2)}");
            m_Console.WriteLine("_____|_____|_____ ");
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {GetCellValue(3)}  |  {GetCellValue(4)}  |  {GetCellValue(5)}");
            m_Console.WriteLine("_____|_____|_____ ");
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {GetCellValue(6)}  |  {GetCellValue(7)}  |  {GetCellValue(8)}");
            m_Console.WriteLine("     |     |      ");
        }
    }
}
