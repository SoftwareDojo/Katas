namespace CSharpKatas.TicTacToe
{
    public class Player
    { 
        public string Name { get; }
        public char Token { get; }

        public Player(string name, char token)
        {
            Name = name;
            Token = token;
        }
    }
}
