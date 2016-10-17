using Xunit;
using System.Linq;
using Katas.Sudoku;

namespace KatasFacts.Sudoku
{
    public class SudokuFact
    {
        [Fact]
        public void Unsolvable()
        {
            // arrange
            var solver = new SudokuSolver();
            var actual = GetEmpty4Sudoku();

            // act
            solver.Solve(actual);

            // assert
            var expected = GetEmpty4Sudoku();
            Assert.True(expected.Cast<int>().SequenceEqual(actual.Cast<int>()));
        }

        [Fact]
        public void SolveByColumn()
        {
            // arrange
            var solver = new SudokuSolver();
            var actual = GetSolved4Sudoku();
            actual[0, 0] = 0;
            actual[0, 1] = 0;
            actual[0, 2] = 0;
            actual[0, 3] = 0;
            //|0 0|0 0|
            //|4 1|2 3|
            //|1 4|3 2|
            //|3 2|1 4|

            // act
            solver.Solve(actual);

            // assert
            var expected = GetSolved4Sudoku();
            Assert.True(expected.Cast<int>().SequenceEqual(actual.Cast<int>()));
        }

        [Fact]
        public void SolveByRow()
        {
            // arrange
            var solver = new SudokuSolver();
            var actual = GetSolved4Sudoku();
            actual[0, 3] = 0;
            actual[1, 3] = 0;
            actual[2, 3] = 0;
            actual[3, 3] = 0;
            //|2 3|4 0|
            //|4 1|2 0|
            //|1 4|3 0|
            //|3 2|1 0|

            // act
            solver.Solve(actual);

            // assert
            var expected = GetSolved4Sudoku();
            Assert.True(expected.Cast<int>().SequenceEqual(actual.Cast<int>()));
        }

        [Fact]
        public void Solve_9_Sudoku()
        {
            // arrange
            var solver = new SudokuSolver();
            var actual = GetUnSolved9Sudoku();

            // act
            solver.Solve(actual);

            // assert
            var expected = GetSolved9Sudoku();
            Assert.True(expected.Cast<int>().SequenceEqual(actual.Cast<int>()));
        }

        [Fact]
        public void Solve_4_Sudoku()
        {
            // arrange
            var solver = new SudokuSolver();
            var actual = GetSolved4Sudoku();
            actual[0, 0] = 0;
            actual[0, 3] = 0;
            actual[1, 1] = 0;
            actual[1, 2] = 0;
            actual[2, 1] = 0;
            actual[2, 2] = 0;
            actual[3, 0] = 0;
            actual[3, 3] = 0;
            //|  3|4  |
            //|4  |  3|
            //|1  |  2|
            //|  2|1  |

            // act
            solver.Solve(actual);

            // assert
            var expected = GetSolved4Sudoku();
            Assert.True(expected.Cast<int>().SequenceEqual(actual.Cast<int>()));
        }

        private int[,] GetEmpty4Sudoku()
        {
            return new[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            //|0 0|0 0|
            //|0 0|0 0|
            //|0 0|0 0|
            //|0 0|0 0|
        }

        private int[,] GetSolved4Sudoku()
        {
            return new[,] { { 2, 3, 4, 1 }, { 4, 1, 2, 3 }, { 1, 4, 3, 2 }, { 3, 2, 1, 4 } };
            //|2 3|4 1|
            //|4 1|2 3|
            //|1 4|3 2|
            //|3 2|1 4|
        }

        private int[,] GetSolved9Sudoku()
        {
            return new[,]
            {
                {3, 9, 4, 8, 5, 2, 6, 7, 1},
                {2, 6, 8, 3, 7, 1, 4, 5, 9},
                {5, 7, 1, 6, 9, 4, 8, 2, 3},
                {1, 4, 5, 7, 8, 3, 9, 6, 2},
                {6, 8, 2, 9, 4, 5, 3, 1, 7},
                {9, 3, 7, 1, 2, 6, 5, 8, 4},
                {4, 1, 3, 5, 6, 7, 2, 9, 8},
                {7, 5, 9, 2, 3, 8, 1, 4, 6},
                {8, 2, 6, 4, 1, 9, 7, 3, 5},
            };
            //|3 9 4|8 5 2|6 7 1|
            //|2 6 8|3 7 1|4 5 9|
            //|5 7 1|6 9 4|8 2 3|
            //|1 4 5|7 8 3|9 6 2|
            //|6 8 2|9 4 5|3 1 7|
            //|9 3 7|1 2 6|5 8 4|
            //|4 1 3|5 6 7|2 9 8|
            //|7 5 9|2 3 8|1 4 6|
            //|8 2 6|4 1 9|7 3 5|
        }

        private int[,] GetUnSolved9Sudoku()
        {
            return new[,]
            {
                {3, 9, 4, 0, 0, 2, 6, 7, 0},
                {0, 0, 0, 3, 0, 0, 4, 0, 0},
                {5, 0, 0, 6, 9, 0, 0, 2, 0},
                {0, 4, 5, 0, 0, 0, 9, 0, 0},
                {6, 0, 0, 0, 0, 0, 0, 0, 7},
                {0, 0, 7, 0, 0, 0, 5, 8, 0},
                {0, 1, 0, 0, 6, 7, 0, 0, 8},
                {0, 0, 9, 0, 0, 8, 0, 0, 0},
                {0, 2, 6, 4, 0, 0, 7, 3, 5},
            };
            //[3 9 4|    2|6 7  ]
            //|     |3    |4    |
            //|5    |6 9  |  2  |
            //|  4 5|     |9    |
            //|6    |     |    7|
            //|    7|     |5 8  |
            //|  1  |  6 7|    8|
            //|    9|    8|     |
            //|  2 6|4    |7 3 5|
        }
    }
}
