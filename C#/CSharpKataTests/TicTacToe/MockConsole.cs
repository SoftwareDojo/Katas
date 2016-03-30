using CSharpKatas.TicTacToe;

namespace CSharpKataTests.TicTacToe
{
    public class MockConsole : IConsole
    {
        public void WriteLine(string text) { }

        public string ReadLine()
        {
            return string.Empty;
        }

        public void Clear() { }
    }
}