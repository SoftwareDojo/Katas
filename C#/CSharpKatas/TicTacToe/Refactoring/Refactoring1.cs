using System.Threading;
using CSharpKatas.TicTacToe.Refactoring;

namespace CSharpKatas.TicTacToe.Refactoring1
{
    public class TicTacToe1
    {
        private readonly IConsole m_Console;

        //making array and   
        //by default I am providing 0-9 where no use of zero  
        private char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int player = 1; //By default player 1 is set  
        private int choice; //This holds the choice at which position user want to mark   

        // The flag veriable checks who has won if it's value is 1 then some one has won the match if -1 then Match has Draw if 0 then match is still running  
        private int flag = 0;

        public TicTacToe1() : this(new ConsoleAdapter()) { }

        public TicTacToe1(IConsole console)
        {
            m_Console = console;
        }

        public void Main()
        {
            do
            {
                m_Console.Clear();// whenever loop will be again start then screen will be clear  
                m_Console.WriteLine("Player1:X and Player2:O");
                m_Console.WriteLine("\n");
                if (player % 2 == 0)//checking the chance of the player  
                {
                    m_Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    m_Console.WriteLine("Player 1 Chance");
                }
                m_Console.WriteLine("\n");
                Board();// calling the board Function  
                choice = int.Parse(m_Console.ReadLine());//Taking users choice   

                // checking that position where user want to run is marked (with X or O) or not  
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //if chance is of player 2 then mark O else mark X  
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else //If there is any possition where user want to run and that is already marked then show message and load board again  
                {
                    m_Console.WriteLine($"Sorry the row {choice} is already marked with {arr[choice]}");
                    m_Console.WriteLine("\n");
                    m_Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// calling of check win  
            } while (flag != 1 && flag != -1);// This loof will be run until all cell of the grid is not marked with X and O or some player is not win  

            m_Console.Clear();// clearing the console  
            Board();// getting filled board again  

            if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  
            {
                m_Console.WriteLine($"Player {(player % 2) + 1} has won");
            }
            else// if flag value is -1 the match will be draw and no one is winner  
            {
                m_Console.WriteLine("Draw");
            }
            m_Console.ReadLine();
        }

        private void Board()
        {
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            m_Console.WriteLine("_____|_____|_____ ");
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            m_Console.WriteLine("_____|_____|_____ ");
            m_Console.WriteLine("     |     |      ");
            m_Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            m_Console.WriteLine("     |     |      ");
        }

        //Checking that any player has won or not  
        private int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }
    }
}

