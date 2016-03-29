
namespace CSharpKatas.TicTacToe
{
    public class Token
    {
        public Position Position { get; private set; }
        public string Value { get; private set; }

        public Token(int x, int y, string value)
        {
            Position = new Position(x, y);
            Value = value;
        }
    }
}