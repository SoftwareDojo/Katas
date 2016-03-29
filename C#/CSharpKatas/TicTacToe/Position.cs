namespace CSharpKatas.TicTacToe
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position)obj);
        }

        public bool Equals(Position position)
        {
            return (position.X == X && position.Y == Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                return (hashCode * 397) ^ Y.GetHashCode();
            }
        }
    }
}