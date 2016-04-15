using System;
using System.Collections.Generic;

namespace CSharpKatas.Sudoku
{
    public class SudokuSolver
    {
        private Square[] m_Squares;

        public void Solve(IList<int[,]> squaresValues)
        {
            Load(squaresValues);

            int squareSize = (int)Math.Sqrt(m_Squares.Length);
            bool changed;

            do
            {
                changed = false;

                foreach (Square square in m_Squares)
                {
                    bool squareChanged = SolveSquare(square, squareSize);
                    if (!changed && squareChanged) changed = true;
                }

            } while (changed);

        }

        private bool SolveSquare(Square square, int squareSize)
        {
            for (int i = 0; i < squareSize; i++)
            {
                var columnValues = square.GetColumnValues(i);
            }

            return false;
        }



        private void Load(IList<int[,]> squaresValues)
        {
            m_Squares = new Square[squaresValues.Count];

            for (int i = 0; i < squaresValues.Count; i++)
            {
                m_Squares[i] = new Square(squaresValues[i]);
            }
        }
    }
}
