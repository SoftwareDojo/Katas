using System;

namespace CSharpKatas.TicTacToe
{
    public interface IConsole
    {
        void WriteLine(string text);
        string ReadLine();
        void Clear();
    }

    public class ConsoleAdapter : IConsole
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
