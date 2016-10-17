using System;
using System.Collections.Generic;

namespace Katas.Sudoku
{
    public class SudokuSolver
    {
        private struct Cell
        {
            public int X { get; }
            public int Y { get; }

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public void Solve(int[,] cells)
        {
            int xLength = cells.GetLength(0);
            int yLength = cells.GetLength(1);
            int sqrtRoot = (int)Math.Sqrt(xLength);

            var emptyCells = GetEmptyCells(cells, xLength, yLength);
            bool unsolvable = false;

            while (!unsolvable)
            {
                unsolvable = true;

                foreach (var cell in emptyCells)
                {
                    var rowValues = GetRowValues(cells, cell.X, yLength);
                    var columnValues = GetColumnValues(cells, cell.Y, xLength);
                    var squareValues = GetSquareValues(cells, cell.X, cell.Y, sqrtRoot);

                    var values = GetPossibleValues(rowValues, columnValues, squareValues, xLength);

                    if (values.Count != 1) continue;
                    {
                        cells[cell.X, cell.Y] = values[0];
                        unsolvable = false;
                    }
                }
            }
        }

        private IList<Cell> GetEmptyCells(int[,] cells, int xLength, int yLength)
        {
            var result = new List<Cell>();

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (cells[x, y] != 0) continue;
                    result.Add(new Cell(x, y));
                }
            }

            return result;
        }

        private IList<int> GetRowValues(int[,] cells, int x, int yLength)
        {
            var result = new List<int>();

            for (int y = 0; y < yLength; y++)
            {
                if (cells[x, y] != 0) result.Add(cells[x, y]);
            }

            return result;
        }

        private IList<int> GetColumnValues(int[,] cells, int y, int xLength)
        {
            var result = new List<int>();

            for (int x = 0; x < xLength; x++)
            {
                if (cells[x, y] != 0) result.Add(cells[x, y]);
            }

            return result;
        }

        private IList<int> GetSquareValues(int[,] cells, int x, int y, int sqrtRoot)
        {
            var result = new List<int>();

            int xLeft = x % sqrtRoot;
            int yLeft = y % sqrtRoot;

            for (var i = x - xLeft; i < x - xLeft + sqrtRoot; i++)
            {
                for (var j = y - yLeft; j < y - yLeft + sqrtRoot; j++)
                {
                    if (cells[i, j] != 0) result.Add(cells[i, j]);
                }
            }

            return result;
        }

        private IList<int> GetPossibleValues(IList<int> xValues, IList<int> yValues, IList<int> sValues, int range)
        {
            var result = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                if (xValues.Contains(i) || yValues.Contains(i) || sValues.Contains(i)) continue;
                result.Add(i);
            }

            return result;
        }
    }
}
