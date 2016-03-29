using CSharpKatas.TicTacToe;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var tto = TicTacToe.Default();
            tto.Start();
        }
    }
}
