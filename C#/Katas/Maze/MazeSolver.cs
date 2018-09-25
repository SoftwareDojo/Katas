using System.IO;
using System.Linq;

namespace Katas.Maze
{
    public class MazeSolver
    {
        internal const string StartMark = "S";
        internal const string EndMark = "E";
        private const string MoveMark = "X";
        private readonly Position myNullPosition = new Position(-1, -1);

        private struct Position
        {
            public Position(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public readonly int Row;
            public readonly int Column;
        }

        public string[] Solve(string[] maze)
        {
            var rows = maze.Select(s => s.Split(' ')).ToArray();

            var start = FindPosition(StartMark, rows);
            if (start.Equals(myNullPosition)) throw new InvalidDataException("Startposition is not defined!");
      
            var end = FindPosition(EndMark, rows);
            if (end.Equals(myNullPosition)) throw new InvalidDataException("Endposition is not defined!");

            return Move(start, end, rows).Select(s => string.Join(" ", s)).ToArray();
        }

        private string[][] Move(Position start, Position end, string[][] rows)
        {
            if (start.Row == end.Row)
            {
                if (start.Column < end.Column) MoveRight(start, rows);
                else MoveLeft(start, rows);
            }
            else if (start.Column == end.Column)
            {
                if (start.Row < end.Row) MoveDown(start, rows);
                else MoveUp(start, rows);
            }
            else
            {
                var current = MoveRight(start, rows);
                if (!current.Equals(start)) return Move(current, end, rows);
                current = MoveDown(start, rows);
                if (!current.Equals(start)) return Move(current, end, rows);
                current = MoveLeft(start, rows);
                if (!current.Equals(start)) return Move(current, end, rows);
                current = MoveUp(start, rows);
                if (!current.Equals(start)) return Move(current, end, rows);
            }

            return rows;
        }

        private Position MoveRight(Position start, string[][] rows)
        {
            int column;
            for (column = start.Column + 1; column < rows[start.Row].Length; column++)
            {
                if (!IsPositionValid(start.Row, column, rows)) return new Position(start.Row, column-1);

                rows[start.Row][column] = MoveMark;
            }

            return new Position(start.Row, column-1);
        }

        private Position MoveLeft(Position start, string[][] rows)
        {
            int column;
            for (column = start.Column - 1; column >= 0; column--)
            {
                if (!IsPositionValid(start.Row, column, rows)) return new Position(start.Row, column+1);

                rows[start.Row][column] = MoveMark;
            }

            return new Position(start.Row, column+1);
        }

        private Position MoveDown(Position start, string[][] rows)
        {
            int row;
            for (row = start.Row + 1; row < rows.Length; row++)
            {
                if (!IsPositionValid(row, start.Column, rows)) return new Position(row-1, start.Column);

                rows[row][start.Column] = MoveMark;
            }

            return new Position(row-1, start.Column);
        }

        private Position MoveUp(Position start, string[][] rows)
        {
            int row;
            for (row = start.Row - 1; row >= 0; row--)
            {
                if (!IsPositionValid(row, start.Column, rows)) return new Position(row+1, start.Column);

                rows[row][start.Column] = MoveMark;
            }

            return new Position(row-1, start.Column);
        }

        private Position FindPosition(string pos, string[][] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == pos) return new Position(i, j);
                }
            }

            return myNullPosition;
        }

        private bool IsPositionValid(int row, int column, string[][] rows)
        {
            if (rows[row][column] == StartMark) return false;
            if (rows[row][column] == EndMark) return false;
            if (rows[row][column] == MoveMark) return false;

            return true;
        }
    }
}
