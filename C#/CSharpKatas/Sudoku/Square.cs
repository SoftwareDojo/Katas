using System.Collections.Generic;
using System.Linq;

namespace CSharpKatas.Sudoku
{
    public class Square
    {
        private readonly int[,] m_Cells;
        private int m_MaxValue;

        public Square(int[,] values)
        {
            m_Cells = (int[,]) values.Clone();
            m_MaxValue = 0;
        }

        public IList<int> GetValues()
        {
            return CellValues().Where(v => v > 0).ToList();
        }

        public IList<int> GetRowValues(int row)
        {
            var result = new List<int>();

            for (int i = 0; i < m_Cells.GetLength(0); i++)
            {
                var value = m_Cells[row, i];
                if (value == 0) continue;
                result.Add(value);
            }

            return result;
        }

        public IList<int> GetColumnValues(int column)
        {
            var result = new List<int>();

            for (int i = 0; i < m_Cells.GetLength(1); i++)
            {
                var value = m_Cells[i, column];
                if (value == 0) continue;
                result.Add(value);
            }

            return result;
        }

        public int GetMaxCellValue
        {
            get
            {
                if (m_MaxValue == 0 )
                    m_MaxValue = m_Cells.GetLength(0) * m_Cells.GetLength(1);

                return m_MaxValue;
            }
        }

        private IList<int> GetListRange(int range)
        {
            var values = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                values.Add(i);
            }
            return values;
        } 

        private IEnumerable<int> CellValues()
        {
            for (int i = 0; i < m_Cells.GetLength(1); i++)
            {
                for (int j = 0; j < m_Cells.GetLength(0); j++)
                {
                    yield return m_Cells[i, j];
                }
            }
        }
    }
}