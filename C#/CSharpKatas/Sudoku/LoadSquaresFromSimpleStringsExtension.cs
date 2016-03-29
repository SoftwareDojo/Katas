using System.Collections.Generic;

namespace CSharpKatas.Sudoku
{
    public static class LoadSquaresFromSimpleStringsExtension
    {
        private const char s_DefaultSeperator = ',';

        public static IList<int[,]> Load(this SudokuSolver solver, string[] values)
        {
            return Load(solver, values, s_DefaultSeperator);
        }

        public static IList<int[,]> Load(this SudokuSolver solver, string[] values, char seperator)
        {
            return null;

            //double squareRoot = Math.Sqrt(m_Squares.Length);

            //int rowIndex = 0;
            //foreach (string value in values)
            //{
            //    var cellValues = value.Split(s_Seperator).Select(v => Convert.ToInt32(v)).ToArray();
            //    if (Math.Sqrt(cellValues.Length) != squareRoot) throw new ArgumentException($"Invalid value count, expected {squareRoot} but was {cellValues.Length}");

            //    int columnIndex = 0;
            //    for (int i = 0; i < cellValues.Length; i++)
            //    {


            //        columnIndex++;
            //        if (columnIndex == (int)squareRoot) columnIndex = 0;
            //    }

            //    rowIndex++;
            //    if (rowIndex == (int)squareRoot) rowIndex = 0;
            //}

            //for (int i = 0; i < m_Squares.Length; i++)
            //{
            //    m_Squares[i] = new Square();
            //}
        }
    }
}
