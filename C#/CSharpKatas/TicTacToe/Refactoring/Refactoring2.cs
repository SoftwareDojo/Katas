using System.Linq;
using System.Threading.Tasks;
using CSharpKatas.TicTacToe.Refactoring;

namespace CSharpKatas.TicTacToe.Refactoring2
{
    public class TicTacToe
    {
        private readonly IConsole m_Console;
        private readonly Player[] m_Players;
        private Player m_CurrentPlayer;
        private const char s_EmptyCell = '0';
        private readonly char[] m_Cells =
        {
            s_EmptyCell, s_EmptyCell, s_EmptyCell,
            s_EmptyCell, s_EmptyCell, s_EmptyCell,
            s_EmptyCell, s_EmptyCell, s_EmptyCell,
        };

        public TicTacToe() : this(new ConsoleAdapter()) { }

        public TicTacToe(IConsole console)
        {
            m_Console = console;
            m_Players = new Player[2];
            m_Players[0] = new Player("Player 1", 'X');
            m_Players[1] = new Player("Player 2", 'O');
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

            if (!isIntValue || index < 0 || index > 8 || m_Cells[index] != s_EmptyCell)
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
            if (m_Cells[index] == s_EmptyCell) return (index+1).ToString();
            return m_Cells[index].ToString();
        }

        private bool PlayerWins(char value)
        {
            if (CheckCellValues(value, 0, 1, 2)) return true;
            if (CheckCellValues(value, 3, 4, 5)) return true;
            if (CheckCellValues(value, 6, 7, 8)) return true;

            if (CheckCellValues(value, 0, 3, 6)) return true;
            if (CheckCellValues(value, 1, 4, 7)) return true;
            if (CheckCellValues(value, 2, 5, 8)) return true;

            if (CheckCellValues(value, 0, 4, 8)) return true;
            if (CheckCellValues(value, 2, 4, 6)) return true;

            return false;
        }

        private bool IsDraw()
        {
            return !m_Cells.Any(a => a == s_EmptyCell);
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

