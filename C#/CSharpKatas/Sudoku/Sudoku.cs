using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.Sudoku
{
    public class SudokuSolver
    {
        private readonly int m_Size;
        private const char s_Seperator = ',';

        private Square[] m_Squares;

        public SudokuSolver() : this(9) { }

        private SudokuSolver(int size)
        {
            m_Size = size;
        }

        public void Load(IList<int[,]> squaresValues)
        {
            m_Squares = new Square[squaresValues.Count];

            for (int i = 0; i < squaresValues.Count; i++)
            {
                m_Squares[i] = new Square(squaresValues[i]);
            }
        }

        public void Start()
        {
            double squareRoot = Math.Sqrt(m_Squares.Length);
            bool changed;

            do
            {
                changed = false;

                foreach (Square square in m_Squares)
                {
                    var values = square.GetValues();
                    //if (values.)
                }

            } while (changed);

        }

        public string[] Solve(string[] rows)
        {
            var cells = PrepareCells(rows);
            bool changed;

            do
            {
                changed = false;

                for (int row = 0; row < m_Size; row++)
                {
                    for (int column = 0; column < m_Size; column++)
                    {
                        if (cells[row, column] > 0 ) continue;

                        int value;
                        if (TryGetCellValue(cells, row, column, out value))
                        {
                            cells[row, column] = value;
                            changed = true;
                        }
                    }
                }

            } while (changed);
            // in block
            // in row
            // in column

            return PrepareStrings(cells);
        }

        private bool TryGetCellValue(int[,] cells, int row, int column, out int value)
        {
            value = 0;
            var usedValues = GetCellValues();

            // row 
            for (int i = 0; i < m_Size; i++)
            {
                var cellValue = cells[row, i];
                if (cellValue == 0 || usedValues[cellValue]) continue;
                usedValues[cellValue] = true;
            }

            // column
            for (int i = 0; i < m_Size; i++)
            {
                var cellValue = cells[i, column];
                if (cellValue == 0 || usedValues[cellValue]) continue;
                usedValues[cellValue] = true;
            }



            var possibleValues = usedValues.Where(pair => !pair.Value).Select(pair => pair.Key).ToList();
            if (possibleValues.Count == 1)
            {
                value = possibleValues[0];
                return true;
            } 

            return false;
        }

        private IDictionary<int, bool> GetCellValues()
        {
            var result = new Dictionary<int, bool>();

            for (int i = 1; i <= m_Size; i++)
            {
                result.Add(i, false);
            }

            return result;
        } 

        private int[,] PrepareCells(string[] rows)
        {
            if (rows.Length != m_Size) throw new ArgumentException(string.Format("expected {0} rows", m_Size));
            int[,] cells = new int[m_Size,m_Size];

            for (int r = 0; r < m_Size; r++)
            {
                var columns = rows[r].Split(s_Seperator).Select(column => Convert.ToInt32(column)).ToArray();
                if (columns.Length != m_Size) throw new ArgumentException(string.Format("expected {0} columns in row {1}", m_Size, r+1));

                for (int c = 0; c < columns.Length; c++)
                {
                    cells[r, c] = columns[c];
                }
            }

            return cells;
        }

        private string[] PrepareStrings(int[,] cells)
        {
            var result = new string[m_Size];

            for (int i = 0; i < m_Size; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < m_Size; j++)
                {
                    list.Add(cells[i,j]);
                }

                result[i] = string.Join(s_Seperator.ToString(), list);
            }

            return result;
        }
    }
}
