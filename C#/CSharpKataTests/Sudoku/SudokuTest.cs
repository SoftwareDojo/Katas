using System;
using System.Collections.Generic;
using CSharpKatas.Sudoku;
using NUnit.Framework;

namespace CSharpKataTests.Sudoku
{
    //PUZZLE
    //[  ,  , 3,  ,  ,  ,  ,  ,  ]
    //[ 4,  ,  ,  , 8,  ,  , 3, 6]
    //[  ,  , 8,  ,  ,  , 1,  , .]
    //[  , 4,  ,  , 6,  ,  , 7, 3]
    //[  ,  ,  , 9,  ,  ,  ,  , .]
    //[  ,  ,  ,  ,  , 2,  ,  , 5]
    //[  ,  , 4,  , 7,  ,  , 6, 8]
    //[ 6,  ,  ,  ,  ,  ,  ,  , .]
    //[ 7,  ,  , 6,  ,  , 5,  , .]

    //SOLUTION
    //[ 1, 2, 3, 4, 5, 6, 7, 8, 9]
    //[ 4, 5, 7, 1, 8, 9, 2, 3, 6]
    //[ 9, 6, 8, 3, 2, 7, 1, 5, 4]
    //[ 2, 4, 9, 5, 6, 1, 8, 7, 3]
    //[ 5, 7, 6, 9, 3, 8, 4, 1, 2]
    //[ 8, 3, 1, 7, 4, 2, 6, 9, 5]
    //[ 3, 1, 4, 2, 7, 5, 9, 6, 8]
    //[ 6, 9, 5, 8, 1, 4, 3, 2, 7]
    //[ 7, 8, 2, 6, 9, 3, 5, 4, 1]

    //PUZZLE
    //[3 9 4|    2|6 7  ]
    //|     |3    |4    |
    //|5    |6 9  |  2  |
    //|  4 5|     |9    |
    //|6    |     |    7|
    //|    7|     |5 8  |
    //|  1  |  6 7|    8|
    //|    9|    8|     |
    //|  2 6|4    |7 3 5|

    //SOLUTION
    //|3 9 4|8 5 2|6 7 1|
    //|2 6 8|3 7 1|4 5 9|
    //|5 7 1|6 9 4|8 2 3|
    //|1 4 5|7 8 3|9 6 2|
    //|6 8 2|9 4 5|3 1 7|
    //|9 3 7|1 2 6|5 8 4|
    //|4 1 3|5 6 7|2 9 8|
    //|7 5 9|2 3 8|1 4 6|
    //|8 2 6|4 1 9|7 3 5|

    //[ 8, 5,  ,  ,  , 2, 4,  ,  ]
    //[ 7, 2,  ,  ,  ,  ,  ,  , 9]
    //[  ,  , 4,  ,  ,  ,  ,  ,  ]
    //[  ,  ,  , 1,  , 7,  ,  , 2]
    //[ 3,  , 5,  ,  ,  , 9,  ,  ]
    //[  , 4,  ,  ,  ,  ,  ,  ,  ]
    //[  ,  ,  ,  , 8,  ,  , 7,  ]
    //[  , 1, 7,  ,  ,  ,  ,  ,  ]
    //[  ,  ,  ,  , 3, 6,  , 4,  ]

    [TestFixture]
    public class SudokuTest
    {
        [Test]
        public void Test()
        {
            var result = new SudokuSolver().Solve(
                new string[] {
                    "3,9,4,0,0,2,6,7,0" ,
                    "0,0,0,3,0,0,4,0,0" ,
                    "5,0,0,6,9,0,0,2,0" ,

                    "0,4,5,0,0,0,9,0,0" ,
                    "6,0,0,0,0,0,0,0,7" ,
                    "0,0,7,0,0,0,5,8,0" ,

                    "0,1,0,0,6,7,0,0,8" ,
                    "0,0,9,0,0,8,0,0,0" ,
                    "0,2,6,4,0,0,7,3,5"});

            Assert.AreEqual("3,9,4,8,5,2,6,7,1", result[0]);
            Assert.AreEqual("2,6,8,3,7,1,4,5,9", result[1]);
            Assert.AreEqual("5,7,1,6,9,4,8,2,3", result[2]);
            Assert.AreEqual("1,4,5,7,8,3,9,6,2", result[3]);
            Assert.AreEqual("6,8,2,9,4,5,3,1,7", result[4]);
            Assert.AreEqual("9,3,7,1,2,6,5,8,4", result[5]);
            Assert.AreEqual("4,1,3,5,6,7,2,9,8", result[6]);
            Assert.AreEqual("7,5,9,2,3,8,1,4,6", result[7]);
            Assert.AreEqual("8,2,6,4,1,9,7,3,5", result[8]);
        }

        [Test]
        public void Test_4xSquare_GetAllValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3, 4 }, square.GetValues());
        }

        [Test]
        public void Test_9xSquare_GetAllValues()
        {
            // arrange
            var square = new Square(new int[3, 3] { { 3, 9, 4 }, { 0, 0, 0 }, { 5, 0, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3, 9, 4, 5 }, square.GetValues());
        }   

        [Test]
        public void Test_Square_GetRowValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3 }, square.GetRowValues(0));
            CollectionAssert.AreEqual(new List<int> { 4 }, square.GetRowValues(1));
        }

        [Test]
        public void Test_Square_GetColumnValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 4 }, square.GetColumnValues(0));
            CollectionAssert.AreEqual(new List<int> { 3 }, square.GetColumnValues(1));
        }

        [Test]
        public void TestSqrt()
        {
            var solver = new SudokuSolver();
            solver.Load(new List<int[,]>
            {
                new [,] { { 0, 3 }, { 4, 0 } },
                new [,] { { 4, 0 }, { 0, 2 } },
                new [,] { { 1, 0 }, { 0, 2 } },
                new [,] { { 0, 2 }, { 1, 0 } }
            }) ;
        }
    }
}
